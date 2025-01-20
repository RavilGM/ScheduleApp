using ScheduleAppContracts.BindingModels;
using ScheduleAppContracts.ViewModels;
using ScheduleAppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScheduleAppListImplement.Models
{
    public class Schedule : IScheduleModel
    {
        public int Id { get; private set; }

        public int SubjectId { get; private set; }

        public int RoomId { get; private set; }

        public int TeacherId { get; private set; }

        public int GroupId { get; private set; }

        public DateTime Date { get; private set; }

        public static Schedule? Create(ScheduleBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Schedule()
            {
                Id = model.Id,
                SubjectId = model.SubjectId,
                RoomId = model.RoomId,
                TeacherId = model.TeacherId,
                GroupId = model.GroupId,
                Date = model.Date
            };
        }

        public void Update(ScheduleBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            SubjectId = model.SubjectId;
            RoomId = model.RoomId;
            TeacherId = model.TeacherId;
            GroupId = model.GroupId;
            Date = model.Date;
        }

        public ScheduleViewModel GetViewModel => new()
        {
            Id = Id,
            SubjectId = SubjectId,
            RoomId = RoomId,
            TeacherId = TeacherId,
            GroupId = GroupId,
            Date = Date
        };
    }
}
