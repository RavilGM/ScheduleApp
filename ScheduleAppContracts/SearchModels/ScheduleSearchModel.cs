using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppContracts.SearchModels
{
    public class ScheduleSearchModel
    {
        public int? Id { get; set; } 

        public int? SubjectId { get; set; } 

        public int? RoomId { get; set; } 

        public int? TeacherId { get; set; } 

        public int? GroupId { get; set; } 

        public DateTime? Date { get; set; }
    }
}
