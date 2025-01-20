using ScheduleAppContracts.BindingModels;
using ScheduleAppDataModels.Enums;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.StoragesContracts.dbModels
{
    public class User : IUserModel
    {
        public int Id { get; set; }

        public string Login {  get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserRole Role {  get; set; } = UserRole.User;

        public static User? Create(UserBindingModel Model)
        {
            if (Model == null)
            {
                return null;
            }
            return new User()
            {
                Id = Model.Id,
                Login = Model.Login,
                Password = Model.Password,
                Role = Model.Role
            };
        }
        public void Update(UserBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            Login = model.Login;
            Password = model.Password;
            Role = model.Role;
        }
    }
}
