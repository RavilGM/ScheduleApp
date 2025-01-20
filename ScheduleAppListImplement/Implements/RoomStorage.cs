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
    public class RoomStorage : IRoomStorage
    {
        private readonly DataListSingelton _source;

        public RoomStorage()
        {
            _source = DataListSingelton.GetInstance();
        }

        public List<RoomViewModel> GetFullList()
        {
            var result = new List<RoomViewModel>();
            foreach (var room in _source.Rooms)
            {
                result.Add(room.GetViewModel);
            }
            return result;
        }

        public List<RoomViewModel> GetFilteredList(RoomSearchModel model)
        {
            var result = new List<RoomViewModel>();
            if (string.IsNullOrEmpty(model.RoomName))
            {
                return result;
            }
            foreach (var room in _source.Rooms)
            {
                if (room.RoomName.Contains(model.RoomName))
                {
                    result.Add(room.GetViewModel);
                }
            }
            return result;
        }

        public RoomViewModel? GetElement(RoomSearchModel model)
        {
            if (string.IsNullOrEmpty(model.RoomName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var room in _source.Rooms)
            {
                if ((!string.IsNullOrEmpty(model.RoomName) && room.RoomName == model.RoomName) ||
                    (model.Id.HasValue && room.Id == model.Id))
                {
                    return room.GetViewModel;
                }
            }
            return null;
        }

        public RoomViewModel? Insert(RoomBindingModel model)
        {
            model.Id = 1;
            foreach (var room in _source.Rooms)
            {
                if (model.Id <= room.Id)
                {
                    model.Id = room.Id + 1;
                }
            }
            var newRoom = Room.Create(model);
            if (newRoom == null)
            {
                return null;
            }
            _source.Rooms.Add(newRoom);
            return newRoom.GetViewModel;
        }

        public RoomViewModel? Update(RoomBindingModel model)
        {
            foreach (var room in _source.Rooms)
            {
                if (room.Id == model.Id)
                {
                    room.Update(model);
                    return room.GetViewModel;
                }
            }
            return null;
        }

        public RoomViewModel? Delete(RoomBindingModel model)
        {
            for (int i = 0; i < _source.Rooms.Count; ++i)
            {
                if (_source.Rooms[i].Id == model.Id)
                {
                    var element = _source.Rooms[i];
                    _source.Rooms.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
