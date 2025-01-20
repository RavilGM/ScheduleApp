using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.SearchModels;
using ScheduleAppContracts.StoragesContracts;
using ScheduleAppContracts.ViewModels;
using ScheduleAppListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppListImplement.Implements
{
    public class UserStorage : IUserStorage
    {
        private readonly DataListSingelton _source;

        public UserStorage()
        {
            _source = DataListSingelton.GetInstance();
        }

        public List<UserViewModel> GetFullList()
        {
            var result = new List<UserViewModel>();
            foreach (var user in _source.Users)
            {
                result.Add(user.GetViewModel);
            }
            return result;
        }

        public List<UserViewModel> GetFilteredList(UserSearchModel model)
        {
            var result = new List<UserViewModel>();
            if (string.IsNullOrEmpty(model.Login))
            {
                return result;
            }
            foreach (var user in _source.Users)
            {
                if (user.Login.Contains(model.Login))
                {
                    result.Add(user.GetViewModel);
                }
            }
            return result;
        }

        public UserViewModel? GetElement(UserSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Login) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var user in _source.Users)
            {
                if ((!string.IsNullOrEmpty(model.Login) && user.Login == model.Login) ||
                    (model.Id.HasValue && user.Id == model.Id))
                {
                    return user.GetViewModel;
                }
            }
            return null;
        }

        public UserViewModel? Insert(UserBindingModel model)
        {
            model.Id = 1;
            foreach (var user in _source.Users)
            {
                if (model.Id <= user.Id)
                {
                    model.Id = user.Id + 1;
                }
            }
            var newUser = User.Create(model);
            if (newUser == null)
            {
                return null;
            }
            _source.Users.Add(newUser);
            return newUser.GetViewModel;
        }

        public UserViewModel? Update(UserBindingModel model)
        {
            foreach (var user in _source.Users)
            {
                if (user.Id == model.Id)
                {
                    user.Update(model);
                    return user.GetViewModel;
                }
            }
            return null;
        }

        public UserViewModel? Delete(UserBindingModel model)
        {
            for (int i = 0; i < _source.Users.Count; ++i)
            {
                if (_source.Users[i].Id == model.Id)
                {
                    var element = _source.Users[i];
                    _source.Users.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }

        public bool Login(UserBindingModel model)
        {
            foreach (var user in _source.Users)
            {
                if (user.Login == model.Login && user.Password == model.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
