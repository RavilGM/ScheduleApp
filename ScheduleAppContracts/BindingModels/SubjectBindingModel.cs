using ScheduleAppDataModels;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.BindingModels
{
    public class SubjectBindingModel : ISubjectModel
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = string.Empty;
    }
}
