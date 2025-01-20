using ScheduleAppDataModels.Enums;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.BindingModels
{
    public class UserBindingModel : IUserModel
    {
        public int Id { get; set; }    
        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.User;

    }
}
