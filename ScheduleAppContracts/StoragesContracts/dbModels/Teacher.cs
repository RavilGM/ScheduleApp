using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.StoragesContracts.dbModels
{
    public class Teacher : ITeacherModel
    {
        public int Id { get; set; }

        public string TeacherName {  get; set; } = string.Empty;

        public static Teacher? Create(TeacherBindingModel Model)
        {
            if (Model == null)
            {
                return null;
            }
            return new Teacher()
            {
                Id = Model.Id,
                TeacherName = Model.TeacherName
            };
        }
        public void Update(TeacherBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            TeacherName = model.TeacherName;
        }
        public TeacherViewModel GetViewModel => new()
        {
            Id = Id,
            TeacherName = TeacherName
        };
    }
}
