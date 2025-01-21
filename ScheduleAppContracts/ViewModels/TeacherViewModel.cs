using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.ViewModels
{
    public class TeacherViewModel : ITeacherModel, IEquatable<TeacherViewModel>
    {
        public int Id { get; set; }

        [DisplayName("Имя преподавателя")]
        public string TeacherName { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            return base.Equals(obj as TeacherViewModel);
            
        }

        public bool Equals(TeacherViewModel other)
        {
            return other != null && TeacherName == other.TeacherName;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
