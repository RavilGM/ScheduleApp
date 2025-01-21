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
    public class ScheduleViewModel : IScheduleModel
    {
        public int Id { get; set; }

        [DisplayName("Предмет")]
        public string SubjectName { get; set; } = string.Empty;

        [DisplayName("Аудитория")]
        public string RoomName { get; set; } = string.Empty;

        [DisplayName("Преподаватель")]
        public string TeacherName { get; set; } = string.Empty;

        [DisplayName("Группа")]
        public string GroupName { get; set; } = string.Empty;

        [DisplayName("Дата занятия")]
        public DateTime Date { get; set; }

        // Связи с другими моделями (ID)
        public int SubjectId { get; set; }

        public int RoomId { get; set; }

        public int TeacherId { get; set; }

        public int GroupId { get; set; }

        [DisplayName("Номер пары")]
        public LessonNumbers LessonNumbers {  get; set; }
    }
}
