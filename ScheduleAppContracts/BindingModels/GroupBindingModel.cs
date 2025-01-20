using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.BindingModels
{
    public class GroupBindingModel : IGroupModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }
}
