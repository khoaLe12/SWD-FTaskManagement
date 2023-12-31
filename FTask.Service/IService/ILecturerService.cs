﻿using FTask.Repository.Identity;
using FTask.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTask.Service.IService
{
    public interface ILecturerService
    {
        Task<IEnumerable<Lecturer>> GetLecturers(int page, int quantity);
        Task<Lecturer?> GetLectureById(Guid id);
        Task<ServiceResponse> CreateNewLecturer(LecturerVM newEntity);
    }
}
