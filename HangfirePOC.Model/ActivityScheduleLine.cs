using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Model
{
    public enum RequestStatus
    {
        Waiting,
        Processing,
        Complete,
        Failed
    }

    public class ActivityScheduleLine : IEntity
    {
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate { get; set; }
        [Display(Name = "Status")]
        public string StatusText { get { return Status.ToString(); } }
        public RequestStatus Status { get; set; }

        [ForeignKey("ActivitySchedule")]
        public int ActivityScheduleID { get; set; }
        public virtual ActivitySchedule ActivitySchedule { get; set; }

        public int ScheduleLineId { get; set; }

        [Key]
        public int ID { get; set; }
    }
}

