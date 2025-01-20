using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataModels.Enums;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScheduleAppListImplement.Models
{
    internal class User : IUserModel
    {
        public int Id { get; private set; }

        public string Login { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public UserRole Role { get; private set; } = UserRole.User;

        public static User? Create(UserBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new User()
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                Role = model.Role
            };
        }

        public void Update(UserBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            Login = model.Login;
            Password = model.Password;
            Role = model.Role;
        }

        public UserViewModel GetViewModel => new()
        {
            Id = Id,
            Login = Login,
            Password = Password,
            Role = Role
        };
    }
}
