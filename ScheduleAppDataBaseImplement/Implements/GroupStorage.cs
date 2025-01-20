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
    public class GroupStorage : IGroupStorage
    {
        public GroupViewModel? Delete(GroupBindingModel model)
        {
            using var context = new DataBaseImplement();
            var element = context.Groups.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Groups.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public GroupViewModel? GetElement(GroupSearchModel model)
        {
            if (string.IsNullOrEmpty(model.GroupName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            return context.Groups
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.GroupName) && x.GroupName == model.GroupName) ||
                                        (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public List<GroupViewModel> GetFilteredList(GroupSearchModel model)
        {
            if (string.IsNullOrEmpty(model.GroupName))
            {
                return new();
            }
            using var context = new DataBaseImplement();
            return context.Groups
                    .Where(x => x.GroupName.Contains(model.GroupName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<GroupViewModel> GetFullList()
        {
            using var context = new DataBaseImplement();
            return context.Groups
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public GroupViewModel? Insert(GroupBindingModel model)
        {
            var newGroup = Group.Create(model);
            if (newGroup == null)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            context.Groups.Add(newGroup);
            context.SaveChanges();
            return newGroup.GetViewModel;
        }

        public GroupViewModel? Update(GroupBindingModel model)
        {
            using var context = new DataBaseImplement();
            var group = context.Groups.FirstOrDefault(x => x.Id == model.Id);
            if (group == null)
            {
                return null;
            }
            group.Update(model);
            context.SaveChanges();
            return group.GetViewModel;
        }
    }
}
