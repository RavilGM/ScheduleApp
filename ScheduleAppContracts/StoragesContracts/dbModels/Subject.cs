using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScheduleAppContracts.StoragesContracts.dbModels
{
    public class Subject : ISubjectModel
    {
        public int Id { get; set; }

        public string SubjectName {  get; set; } = string.Empty;

        public static Subject? Create(SubjectBindingModel Model)
        {
            if (Model == null)
            {
                return null;
            }
            return new Subject()
            {
                Id = Model.Id,
                SubjectName = Model.SubjectName
            };
        }
        public void Update(SubjectBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            SubjectName = model.SubjectName;
        }
        public SubjectViewModel GetViewModel => new()
        {
            Id = Id,
            SubjectName = SubjectName
        };
    }
}
