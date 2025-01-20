using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.BindingModels
{
    public class RoomBindingModel : IRoomModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = string.Empty;

    }
}
