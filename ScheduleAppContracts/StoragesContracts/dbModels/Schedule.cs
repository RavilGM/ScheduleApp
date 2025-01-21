using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataModels.Enums;
using ScheduleAppDataModels.Models;
using System;

namespace ScheduleAppContracts.StoragesContracts.dbModels
{
    public class Schedule : IScheduleModel
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; } // Навигационное свойство

        public int RoomId { get; set; }
        public Room Room { get; set; } // Навигационное свойство

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } // Навигационное свойство

        public int GroupId { get; set; }
        public Group Group { get; set; } // Навигационное свойство

        public DateTime Date { get; set; }

        public LessonNumbers LessonNumbers {  get; set; }


        public static Schedule? Create(ScheduleBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            // Проверка обязательных полей
            if (model.SubjectId <= 0 || model.RoomId <= 0 || model.TeacherId <= 0 || model.GroupId <= 0 || model.Date == default)
            {
                throw new ArgumentException("Некорректные данные в модели ScheduleBindingModel.");
            }

            return new Schedule()
            {
                Id = model.Id,
                Date = model.Date,
                SubjectId = model.SubjectId,
                RoomId = model.RoomId,
                TeacherId = model.TeacherId,
                GroupId = model.GroupId,
                LessonNumbers = model.LessonNumbers
            };
        }

        public void Update(ScheduleBindingModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Модель не может быть null.");
            }

            // Проверка обязательных полей
            if (model.SubjectId <= 0 || model.RoomId <= 0 || model.TeacherId <= 0 || model.GroupId <= 0 || model.Date == default)
            {
                throw new ArgumentException("Некорректные данные в модели ScheduleBindingModel.");
            }

            Id = model.Id;
            Date = model.Date;
            SubjectId = model.SubjectId;
            RoomId = model.RoomId;
            TeacherId = model.TeacherId;
            GroupId = model.GroupId;
            LessonNumbers = model.LessonNumbers;
        }

        public ScheduleViewModel GetViewModel => new()
        {
            Id = Id,
            SubjectId = SubjectId,
            Date = Date,
            RoomId = RoomId,
            TeacherId = TeacherId,
            GroupId = GroupId,
            LessonNumbers = LessonNumbers,
            RoomName = Room?.RoomName,       // Если есть связь с Room
            TeacherName = Teacher?.TeacherName, // Если есть связь с Teacher
            SubjectName = Subject?.SubjectName, // Если есть связь с Subject
            GroupName = Group?.GroupName       // Если есть связь с Group
        };

    }
}
