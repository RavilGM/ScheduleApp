using Microsoft.EntityFrameworkCore;
using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.StoragesContracts.dbModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataBaseImplement;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleAppDataBaseImplement.Implements
{
    public class ScheduleStorage : IScheduleStorage
    {
        public List<ScheduleViewModel> GetFullList()
        {
            using var context = new DataBaseImplement();
            return context.Schedules
                .Include(s => s.Room)       // Загружаем связанную сущность Room
                .Include(s => s.Teacher)    // Загружаем связанную сущность Teacher
                .Include(s => s.Subject)    // Загружаем связанную сущность Subject
                .Include(s => s.Group)      // Загружаем связанную сущность Group
                .Select(s => new ScheduleViewModel
                {
                    Id = s.Id,
                    Date = s.Date,
                    RoomName = s.Room.RoomName,
                    TeacherName = s.Teacher.TeacherName,
                    SubjectName = s.Subject.SubjectName,
                    GroupName = s.Group.GroupName,
                    SubjectId = s.SubjectId,
                    RoomId = s.RoomId,
                    TeacherId = s.TeacherId,
                    GroupId = s.GroupId
                })
                .ToList();
        }

        public List<ScheduleViewModel> GetFilteredList(ScheduleSearchModel model)
        {
            using var context = new DataBaseImplement();
            return context.Schedules
                .Include(s => s.Room)
                .Include(s => s.Teacher)
                .Include(s => s.Subject)
                .Include(s => s.Group)
                .Where(s => (model.Date.HasValue && s.Date.Date == model.Date.Value.Date) ||
                            (model.Id.HasValue && s.Id == model.Id))
                .Select(s => new ScheduleViewModel
                {
                    Id = s.Id,
                    Date = s.Date,
                    RoomName = s.Room.RoomName,
                    TeacherName = s.Teacher.TeacherName,
                    SubjectName = s.Subject.SubjectName,
                    GroupName = s.Group.GroupName,
                    SubjectId = s.SubjectId,
                    RoomId = s.RoomId,
                    TeacherId = s.TeacherId,
                    GroupId = s.GroupId
                })
                .ToList();
        }

        public ScheduleViewModel? GetElement(ScheduleSearchModel model)
        {
            using var context = new DataBaseImplement();
            return context.Schedules
                .Include(s => s.Room)
                .Include(s => s.Teacher)
                .Include(s => s.Subject)
                .Include(s => s.Group)
                .FirstOrDefault(s => (model.Date.HasValue && s.Date.Date == model.Date.Value.Date) ||
                                     (model.Id.HasValue && s.Id == model.Id))
                ?.GetViewModel;
        }

        public ScheduleViewModel? Insert(ScheduleBindingModel model)
        {
            using var context = new DataBaseImplement();
            var newSchedule = Schedule.Create(model);
            if (newSchedule == null)
            {
                return null;
            }
            context.Schedules.Add(newSchedule);
            context.SaveChanges();
            return newSchedule.GetViewModel;
        }

        public ScheduleViewModel? Update(ScheduleBindingModel model)
        {
            using var context = new DataBaseImplement();
            var schedule = context.Schedules.FirstOrDefault(s => s.Id == model.Id);
            if (schedule == null)
            {
                return null;
            }
            schedule.Update(model);
            context.SaveChanges();
            return schedule.GetViewModel;
        }

        public ScheduleViewModel? Delete(ScheduleBindingModel model)
        {
            using var context = new DataBaseImplement();
            var schedule = context.Schedules.FirstOrDefault(s => s.Id == model.Id);
            if (schedule == null)
            {
                return null;
            }
            context.Schedules.Remove(schedule);
            context.SaveChanges();
            return schedule.GetViewModel;
        }
    }
}