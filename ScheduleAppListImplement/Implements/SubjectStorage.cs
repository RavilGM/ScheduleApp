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
    public class SubjectStorage : ISubjectStorage
    {
        private readonly DataListSingelton _source;

        public SubjectStorage()
        {
            _source = DataListSingelton.GetInstance();
        }

        public List<SubjectViewModel> GetFullList()
        {
            var result = new List<SubjectViewModel>();
            foreach (var subject in _source.Subjects)
            {
                result.Add(subject.GetViewModel);
            }
            return result;
        }

        public List<SubjectViewModel> GetFilteredList(SubjectSearchModel model)
        {
            var result = new List<SubjectViewModel>();
            if (string.IsNullOrEmpty(model.SubjectName))
            {
                return result;
            }
            foreach (var subject in _source.Subjects)
            {
                if (subject.SubjectName.Contains(model.SubjectName))
                {
                    result.Add(subject.GetViewModel);
                }
            }
            return result;
        }

        public SubjectViewModel? GetElement(SubjectSearchModel model)
        {
            if (string.IsNullOrEmpty(model.SubjectName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var subject in _source.Subjects)
            {
                if ((!string.IsNullOrEmpty(model.SubjectName) && subject.SubjectName == model.SubjectName) ||
                    (model.Id.HasValue && subject.Id == model.Id))
                {
                    return subject.GetViewModel;
                }
            }
            return null;
        }

        public SubjectViewModel? Insert(SubjectBindingModel model)
        {
            model.Id = 1;
            foreach (var subject in _source.Subjects)
            {
                if (model.Id <= subject.Id)
                {
                    model.Id = subject.Id + 1;
                }
            }
            var newSubject = Subject.Create(model);
            if (newSubject == null)
            {
                return null;
            }
            _source.Subjects.Add(newSubject);
            return newSubject.GetViewModel;
        }

        public SubjectViewModel? Update(SubjectBindingModel model)
        {
            foreach (var subject in _source.Subjects)
            {
                if (subject.Id == model.Id)
                {
                    subject.Update(model);
                    return subject.GetViewModel;
                }
            }
            return null;
        }

        public SubjectViewModel? Delete(SubjectBindingModel model)
        {
            for (int i = 0; i < _source.Subjects.Count; ++i)
            {
                if (_source.Subjects[i].Id == model.Id)
                {
                    var element = _source.Subjects[i];
                    _source.Subjects.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
