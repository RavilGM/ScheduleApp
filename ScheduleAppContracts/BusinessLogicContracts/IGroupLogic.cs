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
    public interface IGroupLogic
    {
        List<GroupViewModel>? ReadList(GroupSearchModel? model);

        GroupViewModel? ReadElement(GroupSearchModel model);

        bool Create(GroupBindingModel model);

        bool Update(GroupBindingModel model);

        bool Delete(GroupBindingModel model);
    }
}
