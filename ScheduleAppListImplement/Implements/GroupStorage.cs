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
    public class GroupStorage : IGroupStorage
    {
        private readonly DataListSingelton _source;

        public GroupStorage()
        {
            _source = DataListSingelton.GetInstance();
        }

        public List<GroupViewModel> GetFullList()
        {
            var result = new List<GroupViewModel>();
            foreach (var group in _source.Groups)
            {
                result.Add(group.GetViewModel);
            }
            return result;
        }

        public List<GroupViewModel> GetFilteredList(GroupSearchModel model)
        {
            var result = new List<GroupViewModel>();
            if (string.IsNullOrEmpty(model.GroupName))
            {
                return result;
            }
            foreach (var group in _source.Groups)
            {
                if (group.GroupName.Contains(model.GroupName))
                {
                    result.Add(group.GetViewModel);
                }
            }
            return result;
        }

        public GroupViewModel? GetElement(GroupSearchModel model)
        {
            if (string.IsNullOrEmpty(model.GroupName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var group in _source.Groups)
            {
                if ((!string.IsNullOrEmpty(model.GroupName) && group.GroupName == model.GroupName) ||
                    (model.Id.HasValue && group.Id == model.Id))
                {
                    return group.GetViewModel;
                }
            }
            return null;
        }

        public GroupViewModel? Insert(GroupBindingModel model)
        {
            model.Id = 1;
            foreach (var group in _source.Groups)
            {
                if (model.Id <= group.Id)
                {
                    model.Id = group.Id + 1;
                }
            }
            var newGroup = Group.Create(model);
            if (newGroup == null)
            {
                return null;
            }
            _source.Groups.Add(newGroup);
            return newGroup.GetViewModel;
        }

        public GroupViewModel? Update(GroupBindingModel model)
        {
            foreach (var group in _source.Groups)
            {
                if (group.Id == model.Id)
                {
                    group.Update(model);
                    return group.GetViewModel;
                }
            }
            return null;
        }

        public GroupViewModel? Delete(GroupBindingModel model)
        {
            for (int i = 0; i < _source.Groups.Count; ++i)
            {
                if (_source.Groups[i].Id == model.Id)
                {
                    var element = _source.Groups[i];
                    _source.Groups.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
