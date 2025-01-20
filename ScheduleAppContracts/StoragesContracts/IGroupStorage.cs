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
    public interface IGroupStorage
    {
        List<GroupViewModel> GetFullList();

        List<GroupViewModel> GetFilteredList(GroupSearchModel model);

        GroupViewModel? GetElement(GroupSearchModel model);

        GroupViewModel? Insert(GroupBindingModel model);

        GroupViewModel? Update(GroupBindingModel model);

        GroupViewModel? Delete(GroupBindingModel model);
    }
}
