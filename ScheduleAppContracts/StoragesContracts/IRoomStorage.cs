using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.StoragesContracts
{
    public interface IRoomStorage
    {
        List<RoomViewModel> GetFullList();

        List<RoomViewModel> GetFilteredList(RoomSearchModel model);

        RoomViewModel? GetElement(RoomSearchModel model);

        RoomViewModel? Insert(RoomBindingModel model);

        RoomViewModel? Update(RoomBindingModel model);

        RoomViewModel? Delete(RoomBindingModel model);
    }
}
