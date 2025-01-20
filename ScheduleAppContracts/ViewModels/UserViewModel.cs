using ScheduleAppDataModels.Enums;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.ViewModels
{
    public class UserViewModel : IUserModel
    {
        public int Id { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; } = string.Empty;

        [DisplayName("Пароль")]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Роль")]
        public UserRole Role { get; set; } = UserRole.User;

    }
}
