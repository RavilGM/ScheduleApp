using ScheduleAppDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppDataModels.Models
{
    public interface IUserModel : IId
    {
        string Login {  get; }
        string Password { get; }
        UserRole Role {  get; }
    }
}
