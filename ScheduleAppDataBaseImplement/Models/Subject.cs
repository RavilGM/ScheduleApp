using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppListImplement.Models
{
    public class Subject : ISubjectModel
    {
        public int Id { get; private set; }

        public string SubjectName { get; private set; } = string.Empty;

        public static Subject? Create(SubjectBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Subject()
            {
                Id = model.Id,
                SubjectName = model.SubjectName
            };
        }

        public void Update(SubjectBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            SubjectName = model.SubjectName;
        }

        public SubjectViewModel GetViewModel => new()
        {
            Id = Id,
            SubjectName = SubjectName
        };
    }
}
