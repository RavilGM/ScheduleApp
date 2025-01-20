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
    public interface IScheduleLogic
    {
        List<ScheduleViewModel>? ReadList(ScheduleSearchModel? model);

        ScheduleViewModel? ReadElement(ScheduleSearchModel model);

        bool Create(ScheduleBindingModel model);

        bool Update(ScheduleBindingModel model);

        bool Delete(ScheduleBindingModel model);

        bool ExportToExcel(string fileName);
    }
}
