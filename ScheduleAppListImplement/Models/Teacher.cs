using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppListImplement.Models
{
    internal class Teacher : ITeacherModel
    {
        public int Id { get; private set; }

        public string TeacherName { get; private set; } = string.Empty;

        public static Teacher? Create(TeacherBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Teacher()
            {
                Id = model.Id,
                TeacherName = model.TeacherName
            };
        }

        public void Update(TeacherBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            TeacherName = model.TeacherName;
        }

        public TeacherViewModel GetViewModel => new()
        {
            Id = Id,
            TeacherName = TeacherName
        };
    }
}
