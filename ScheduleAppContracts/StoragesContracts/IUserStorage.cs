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
    public interface IUserStorage
    {
        List<UserViewModel> GetFullList();

        List<UserViewModel> GetFilteredList(UserSearchModel model);

        UserViewModel? GetElement(UserSearchModel model);

        UserViewModel? Insert(UserBindingModel model);

        UserViewModel? Update(UserBindingModel model);

        UserViewModel? Delete(UserBindingModel model);

        bool Login(UserBindingModel model); // Метод для авторизации
    }
}
