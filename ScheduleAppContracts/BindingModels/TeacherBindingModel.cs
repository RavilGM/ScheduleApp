using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.BindingModels
{
    public class TeacherBindingModel : ITeacherModel
    {
        public int Id { get; set; }
        public string TeacherName { get; set; } = string.Empty;
    }
}
