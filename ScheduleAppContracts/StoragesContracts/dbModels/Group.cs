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
    public class Group : IGroupModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public static Group? Create(GroupBindingModel Model)
        {
            if (Model == null)
            {
                return null;
            }
            return new Group()
            {
                Id = Model.Id,
                GroupName = Model.GroupName
            };
        }
        public void Update(GroupBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            GroupName = model.GroupName;
        }
        public GroupViewModel GetViewModel => new()
        {
            Id = Id,
            GroupName = GroupName
        };
    }
}
