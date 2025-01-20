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
    public class Room : IRoomModel
    {
        public int Id { get; set; }

        public string RoomName {  get; set; } = string.Empty;

        public static Room? Create(RoomBindingModel Model)
        {
            if (Model == null)
            {
                return null;
            }
            return new Room()
            {
                Id = Model.Id,
                RoomName = Model.RoomName
            };
        }
        public void Update(RoomBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            RoomName = model.RoomName;
        }
        public RoomViewModel GetViewModel => new()
        {
            Id = Id,
            RoomName = RoomName
        };
    }
}
