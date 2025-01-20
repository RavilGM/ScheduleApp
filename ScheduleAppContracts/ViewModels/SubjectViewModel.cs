using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.ViewModels
{
    public class SubjectViewModel : ISubjectModel
    {
        public int Id { get; set; }

        [DisplayName("Название предмета")]
        public string SubjectName { get; set; } = string.Empty;
    }
}
