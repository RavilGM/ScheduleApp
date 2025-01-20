using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.BusinessLogicContracts
{
    public interface IRoomLogic
    {
        List<RoomViewModel>? ReadList(RoomSearchModel? model);

        RoomViewModel? ReadElement(RoomSearchModel model);

        bool Create(RoomBindingModel model);

        bool Update(RoomBindingModel model);

        bool Delete(RoomBindingModel model);

    }
}
