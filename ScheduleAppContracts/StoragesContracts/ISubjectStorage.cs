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
    public interface ISubjectStorage
    {
        List<SubjectViewModel> GetFullList();

        List<SubjectViewModel> GetFilteredList(SubjectSearchModel model);

        SubjectViewModel? GetElement(SubjectSearchModel model);

        SubjectViewModel? Insert(SubjectBindingModel model);

        SubjectViewModel? Update(SubjectBindingModel model);

        SubjectViewModel? Delete(SubjectBindingModel model);
    }
}
