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
    internal class Group : IGroupModel
    {
        public int Id { get; private set; }

        public string GroupName { get; private set; } = string.Empty;

        public static Group? Create(GroupBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Group()
            {
                Id = model.Id,
                GroupName = model.GroupName
            };
        }

        public void Update(GroupBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            GroupName = model.GroupName;
        }

        public GroupViewModel GetViewModel => new()
        {
            Id = Id,
            GroupName = GroupName
        };
    }
}
