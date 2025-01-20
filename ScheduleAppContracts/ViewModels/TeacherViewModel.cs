using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.ViewModels
{
    public class TeacherViewModel : ITeacherModel
    {
        public int Id { get; set; }

        [DisplayName("Имя преподавателя")]
        public string TeacherName { get; set; } = string.Empty;
    }
}
