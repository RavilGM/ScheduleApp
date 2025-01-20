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
    public interface ISubjectLogic
    {
        List<SubjectViewModel>? ReadList(SubjectSearchModel? model);

        SubjectViewModel? ReadElement(SubjectSearchModel model);

        bool Create(SubjectBindingModel model);

        bool Update(SubjectBindingModel model);

        bool Delete(SubjectBindingModel model);

    }
}
