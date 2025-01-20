using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.StoragesContracts.dbModels;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppDataBaseImplement.Implements
{
    public class RoomStorage : IRoomStorage
    {
        public RoomViewModel? Delete(RoomBindingModel model)
        {
            

            using var context = new DataBaseImplement();
            var element = context.Rooms.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Rooms.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public RoomViewModel? GetElement(RoomSearchModel model)
        {
            if (string.IsNullOrEmpty(model.RoomName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            return context.Rooms
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.RoomName) && x.RoomName == model.RoomName) ||
                                        (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public List<RoomViewModel> GetFilteredList(RoomSearchModel model)
        {
            if (string.IsNullOrEmpty(model.RoomName))
            {
                return new();
            }
            using var context = new DataBaseImplement();
            return context.Rooms
                    .Where(x => x.RoomName.Contains(model.RoomName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<RoomViewModel> GetFullList()
        {
            using var context = new DataBaseImplement();
            return context.Rooms
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public RoomViewModel? Insert(RoomBindingModel model)
        {
            var newRoom = Room.Create(model);
            if (newRoom == null)
            {
                return null;
            }
            using var context = new DataBaseImplement();
            context.Rooms.Add(newRoom);
            context.SaveChanges();
            return newRoom.GetViewModel;
        }

        public RoomViewModel? Update(RoomBindingModel model)
        {
            using var context = new DataBaseImplement();
            var room = context.Rooms.FirstOrDefault(x => x.Id == model.Id);
            if (room == null)
            {
                return null;
            }
            room.Update(model);
            context.SaveChanges();
            return room.GetViewModel;
        }
    }
}
