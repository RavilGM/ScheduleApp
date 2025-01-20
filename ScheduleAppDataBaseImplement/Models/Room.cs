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
    internal class Room : IRoomModel
    {
        public int Id { get; private set; }

        public string RoomName { get; private set; } = string.Empty;

        public static Room? Create(RoomBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Room()
            {
                Id = model.Id,
                RoomName = model.RoomName
            };
        }

        public void Update(RoomBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            RoomName = model.RoomName;
        }

        public RoomViewModel GetViewModel => new()
        {
            Id = Id,
            RoomName = RoomName
        };

    }
}
