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
    public interface IScheduleStorage
    {
        List<ScheduleViewModel> GetFullList();

        List<ScheduleViewModel> GetFilteredList(ScheduleSearchModel model);

        ScheduleViewModel? GetElement(ScheduleSearchModel model);

        ScheduleViewModel? Insert(ScheduleBindingModel model);

        ScheduleViewModel? Update(ScheduleBindingModel model);

        ScheduleViewModel? Delete(ScheduleBindingModel model);
    }
}
