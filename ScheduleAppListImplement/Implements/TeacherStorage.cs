using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.ViewModels;
using ScheduleAppListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppListImplement.Implements
{
    public class TeacherStorage : ITeacherStorage
    {
        private readonly DataListSingelton _source;

        public TeacherStorage()
        {
            _source = DataListSingelton.GetInstance();
        }

        public List<TeacherViewModel> GetFullList()
        {
            var result = new List<TeacherViewModel>();
            foreach (var teacher in _source.Teachers)
            {
                result.Add(teacher.GetViewModel);
            }
            return result;
        }

        public List<TeacherViewModel> GetFilteredList(TeacherSearchModel model)
        {
            var result = new List<TeacherViewModel>();
            if (string.IsNullOrEmpty(model.TeacherName))
            {
                return result;
            }
            foreach (var teacher in _source.Teachers)
            {
                if (teacher.TeacherName.Contains(model.TeacherName))
                {
                    result.Add(teacher.GetViewModel);
                }
            }
            return result;
        }

        public TeacherViewModel? GetElement(TeacherSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TeacherName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var teacher in _source.Teachers)
            {
                if ((!string.IsNullOrEmpty(model.TeacherName) && teacher.TeacherName == model.TeacherName) ||
                    (model.Id.HasValue && teacher.Id == model.Id))
                {
                    return teacher.GetViewModel;
                }
            }
            return null;
        }

        public TeacherViewModel? Insert(TeacherBindingModel model)
        {
            model.Id = 1;
            foreach (var teacher in _source.Teachers)
            {
                if (model.Id <= teacher.Id)
                {
                    model.Id = teacher.Id + 1;
                }
            }
            var newTeacher = Teacher.Create(model);
            if (newTeacher == null)
            {
                return null;
            }
            _source.Teachers.Add(newTeacher);
            return newTeacher.GetViewModel;
        }

        public TeacherViewModel? Update(TeacherBindingModel model)
        {
            foreach (var teacher in _source.Teachers)
            {
                if (teacher.Id == model.Id)
                {
                    teacher.Update(model);
                    return teacher.GetViewModel;
                }
            }
            return null;
        }

        public TeacherViewModel? Delete(TeacherBindingModel model)
        {
            for (int i = 0; i < _source.Teachers.Count; ++i)
            {
                if (_source.Teachers[i].Id == model.Id)
                {
                    var element = _source.Teachers[i];
                    _source.Teachers.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
