﻿using FTask.Service.ViewModel;
using FTask.Repository.Data;
using FTask.Repository.Identity;
using Microsoft.AspNetCore.Identity;
using FTask.Service.Validation;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using EntityFramework.Exceptions.Common;
using Role = FTask.Repository.Identity.Role;

namespace FTask.Service.IService;

internal class UserService : IUserService
{
    private readonly UserManager<Lecturer> _lecturerManager;
    private readonly ICheckQuantityTaken _checkQuantityTaken;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Cloudinary _cloudinary;

    public UserService(
        UserManager<User> userManager, 
        RoleManager<Role> roleManager, 
        UserManager<Lecturer> lecturerManager, 
        IUnitOfWork unitOfWork, 
        ICheckQuantityTaken checkQuantityTaken,
        Cloudinary cloudinary)
    {
        _lecturerManager = lecturerManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
        _checkQuantityTaken = checkQuantityTaken;
        _cloudinary = cloudinary;
    }

    public async Task<LoginUserManagement> LoginMember(LoginUserVM resource)
    {
        var existedUser = await _userManager.FindByNameAsync(resource.UserName);
        if (existedUser == null)
        {
            return new LoginUserManagement
            {
                Message = "Invalid Username or password",
                IsSuccess = false,
            };
        }

        var checkPassword = await _userManager.CheckPasswordAsync(existedUser, resource.Password);
        if (!checkPassword)
        {
            return new LoginUserManagement
            {
                Message = "Invalid Username or password",
                IsSuccess = false,
            };
        }

        if (existedUser.LockoutEnabled)
        {
            return new LoginUserManagement
            {
                Message = "Account is locked",
                IsSuccess = false,
            };
        }
        else
        {
            var roles = await _userManager.GetRolesAsync(existedUser);
            return new LoginUserManagement
            {
                Message = "Login Successfully",
                IsSuccess = true,
                LoginUser = existedUser,
                RoleNames = roles
            };
        }
    }

    public async Task<LoginLecturerManagement> LoginLecturer(LoginUserVM resource)
    {
        var existedUser = await _lecturerManager.FindByNameAsync(resource.UserName);
        if (existedUser == null)
        {
            return new LoginLecturerManagement
            {
                Message = "Invalid Username or password",
                IsSuccess = false,
            };
        }

        var checkPassword = await _lecturerManager.CheckPasswordAsync(existedUser, resource.Password);
        if (!checkPassword)
        {
            return new LoginLecturerManagement
            {
                Message = "Invalid Username or password",
                IsSuccess = false,
            };
        }

        if (existedUser.LockoutEnabled)
        {
            return new LoginLecturerManagement
            {
                Message = "Account is locked",
                IsSuccess = false,
            };
        }
        else
        {
            return new LoginLecturerManagement
            {
                Message = "Login Successfully",
                IsSuccess = true,
                LoginUser = existedUser
            };
        }
    }

    public async Task<IEnumerable<User>> GetUsers(int page, int quantity)
    {
        if (page == 0)
        {
            page = 1;
        }
        quantity = _checkQuantityTaken.check(quantity);
        return await _unitOfWork.UserRepository
            .FindAll()
            .Skip((page - 1) * _checkQuantityTaken.PageQuantity)
            .Take(quantity)
            .ToArrayAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _unitOfWork.UserRepository.FindAsync(id);
    }

    public async Task<ServiceResponse> CreateNewUser(UserVM newEntity)
    {
        try
        {
            var existedUser = await _userManager.FindByNameAsync(newEntity.UserName);
            if (existedUser is not null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Username is already taken"
                };
            }

            if (newEntity.Email is not null)
            {
                var existedLecturer = await _unitOfWork.LecturerRepository.Get(l => newEntity.Email.Equals(l.Email)).FirstOrDefaultAsync();
                if (existedLecturer is not null)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "Email is already taken"
                    };
                }
            }

            if (newEntity.PhoneNumber is not null)
            {
                var existedLecturer = await _unitOfWork.LecturerRepository.Get(l => newEntity.PhoneNumber.Equals(l.PhoneNumber)).FirstOrDefaultAsync();
                if (existedLecturer is not null)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "Phone is already taken"
                    };
                }
            }

            User newUser = new User
            {
                UserName = newEntity.UserName,
                PhoneNumber = newEntity.PhoneNumber,
                Email = newEntity.Email,
                LockoutEnabled = newEntity.LockoutEnabled ?? true,
                LockoutEnd = newEntity.LockoutEnd,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false
            };

            if (newEntity.RoleIds.Count() > 0)
            {
                List<Role> roles = new List<Role>();
                foreach (Guid id in newEntity.RoleIds)
                {
                    var existedRole = await _unitOfWork.RoleRepository.FindAsync(id);
                    if (existedRole is null)
                    {
                        return new ServiceResponse
                        {
                            IsSuccess = false,
                            Message = "Create new user failed",
                            Errors = new List<string>() { "Role not found with the given id :" + id }
                        };
                    }
                    else
                    {
                        roles.Add(existedRole);
                    }
                }
                if (roles.Count() > 0)
                {
                    newUser.Roles = roles;
                }
            }

            //Upload file
            var file = newEntity.Avatar;
            if (file is not null && file.Length > 0)
            {
                var uploadFile = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream())
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadFile);

                if (uploadResult.Error is not null)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "Create new lecturer failed",
                        Errors = new string[1] { "Error when upload image" }
                    };
                }
                newUser.FilePath = uploadResult.SecureUrl.ToString();
            };

            var identityResult = await _userManager.CreateAsync(newUser, newEntity.Password);
            if (!identityResult.Succeeded)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Create new lecturer failed",
                    Errors = identityResult.Errors.Select(e => e.Description)
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Id = newUser.Id.ToString(),
                    IsSuccess = true,
                    Message = "Create new lecturer successfully"
                };
            }
        }
        catch (DbUpdateException ex)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = "Some error happened",
                Errors = new List<string>() { ex.Message }
            };
        }
    }
}
