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
    public interface IUserLogic
    {
        List<UserViewModel>? ReadList(UserSearchModel? model);

        UserViewModel? ReadElement(UserSearchModel model);

        bool Create(UserBindingModel model);

        bool Update(UserBindingModel model);

        bool Delete(UserBindingModel model);

        bool Login(UserBindingModel model); // Метод для авторизации
    }
}
