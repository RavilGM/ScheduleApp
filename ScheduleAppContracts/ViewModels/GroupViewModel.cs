using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.ViewModels
{
    public class GroupViewModel : IGroupModel
    {
        public int Id { get; set; }

        [DisplayName("Название группы")]
        public string GroupName { get; set; } = string.Empty;
    }
}
