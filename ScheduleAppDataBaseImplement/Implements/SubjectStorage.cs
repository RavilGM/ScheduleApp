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
    public class SubjectStorage : ISubjectStorage
    {
        public SubjectViewModel? Delete(SubjectBindingModel model)
        {
            using var context = new DataBaseImplement();
            var element = context.Subjects.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Subjects.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
                
            }
            return null;
        }

        public SubjectViewModel? GetElement(SubjectSearchModel model)
        {
            if (string.IsNullOrEmpty(model.SubjectName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            return context.Subjects
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.SubjectName) && x.SubjectName == model.SubjectName) ||
                                        (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public List<SubjectViewModel> GetFilteredList(SubjectSearchModel model)
        {
            if (string.IsNullOrEmpty(model.SubjectName))
            {
                return new();
            }
            using var context = new DataBaseImplement();
            return context.Subjects
                    .Where(x => x.SubjectName.Contains(model.SubjectName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<SubjectViewModel> GetFullList()
        {
            using var context = new DataBaseImplement();
            return context.Subjects
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public SubjectViewModel? Insert(SubjectBindingModel model)
        {
            var newSubject = Subject.Create(model);
            if (newSubject == null)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            context.Subjects.Add(newSubject);
            context.SaveChanges();
            return newSubject.GetViewModel;
        }

        public SubjectViewModel? Update(SubjectBindingModel model)
        {
            using var context = new DataBaseImplement();
            var subject = context.Subjects.FirstOrDefault(x => x.Id == model.Id);
            if (subject == null)
            {
                return null;
            }
            subject.Update(model);
            context.SaveChanges();
            return subject.GetViewModel;
        }
    }
}
