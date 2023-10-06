using FTask.Repository.Entity;
using FTask.Repository.Identity;
using FTask.Repository.IRepository;
using FTask.Service.Caching;
using FTask.Service.IService;
using FTask.Service.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task = FTask.Repository.Entity.Task;

namespace FTask.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
    {

        #region Services
        // Register services
        services.AddScoped<IAttachmentService,AttachmentService>();
        services.AddScoped<IDepartmentService,DepartmentService>();
        services.AddScoped<IEvidenceService,EvidenceService>();
        services.AddScoped<ILecturerService,LecturerService>();
        services.AddScoped<IRoleService,RoleService>();
        services.AddScoped<ISemesterService,SemesterService>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<ISubjectService,SubjectService>();
        services.AddScoped<ITaskActivityService,TaskActivityService>();
        services.AddScoped<ITaskLecturerService,TaskLecturerService>();
        services.AddScoped<ITaskReportService,TaskReportService>();
        services.AddScoped<ITaskService,TaskService>();
        #endregion

        #region Validation
        services.AddSingleton<ICheckQuantityTaken, CheckQuantityTaken>();
        services.AddSingleton<ICheckSemesterPeriod, CheckSemesterPeriod>();
        #endregion

        #region Distributed Cache
        services.AddSingleton<ICacheService<Subject, int>, CacheService<Subject, int>>();
        services.AddSingleton<ICacheService<Department, int>, CacheService<Department, int>>();
        services.AddSingleton<ICacheService<Lecturer, Guid>, CacheService<Lecturer, Guid>>();
        services.AddSingleton<ICacheService<Semester, int>, CacheService<Semester, int>>();
        services.AddSingleton<ICacheService<Task, int>, CacheService<Task, int>>();
        services.AddSingleton<ICacheService<TaskActivity, int>, CacheService<TaskActivity, int>>();
        services.AddSingleton<ICacheService<TaskLecturer, int>, CacheService<TaskLecturer, int>>();
        services.AddSingleton<ICacheService<TaskReport, int>, CacheService<TaskReport, int>>();
        services.AddSingleton<ICacheService<User, Guid>, CacheService<User, Guid>>();
        services.AddSingleton<ICacheService<Role, Guid>, CacheService<Role, Guid>>();
        services.AddSingleton<ICacheService<Attachment, int>, CacheService<Attachment, int>>();
        services.AddSingleton<ICacheService<Evidence, int>, CacheService<Evidence, int>>();
        #endregion

        return services;
    }
}
