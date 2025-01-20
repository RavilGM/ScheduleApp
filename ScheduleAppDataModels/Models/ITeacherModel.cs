using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppDataModels.Models
{
    public interface ITeacherModel : IId
    {
        string TeacherName { get; }  
    }
}
