using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.StoragesContracts.dbModels;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppDataBaseImplement.Implements
{
    public class TeacherStorage : ITeacherStorage
    {
        public TeacherViewModel? Delete(TeacherBindingModel model)
        {
            using var context = new DataBaseImplement();
            var element = context.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Teachers.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;

            }
            return null;
        }

        public TeacherViewModel? GetElement(TeacherSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TeacherName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            return context.Teachers
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.TeacherName) && x.TeacherName == model.TeacherName) ||
                                        (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public List<TeacherViewModel> GetFilteredList(TeacherSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TeacherName))
            {
                return new();
            }
            using var context = new DataBaseImplement();
            return context.Teachers
                    .Where(x => x.TeacherName.Contains(model.TeacherName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<TeacherViewModel> GetFullList()
        {
            using var context = new DataBaseImplement();
            return context.Teachers
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public TeacherViewModel? Insert(TeacherBindingModel model)
        {
            var newTeacher = Teacher.Create(model);
            if (newTeacher == null)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            context.Teachers.Add(newTeacher);
            context.SaveChanges();
            return newTeacher.GetViewModel;
        }

        public TeacherViewModel? Update(TeacherBindingModel model)
        {
            using var context = new DataBaseImplement();
            var teacher = context.Teachers.FirstOrDefault(x => x.Id == model.Id);
            if (teacher == null)
            {
                return null;
            }
            teacher.Update(model);
            context.SaveChanges();
            return teacher.GetViewModel;
        }
    }
}
