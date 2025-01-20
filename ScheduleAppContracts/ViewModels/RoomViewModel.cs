using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.ViewModels
{
    public class RoomViewModel : IRoomModel
    {
        public int Id { get; set; }

        [DisplayName("Название аудитории")]
        public string RoomName { get; set; } = string.Empty;
    }
}
