using ScheduleAppDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppDataModels.Models
{
    public interface IScheduleModel : IId
    {
        int SubjectId { get; }         
        int RoomId { get; }            
        int TeacherId { get; }          
        int GroupId { get; }            
        DateTime Date { get; }

        LessonNumbers LessonNumbers { get; }
    }
}
