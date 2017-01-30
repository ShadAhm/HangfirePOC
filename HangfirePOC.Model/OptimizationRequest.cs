using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class OptimizationRequest : IEntity
    {

        public OptimizationRequest()
        {
            RequestDate = System.DateTime.Now;
            Status = RequestStatus.Waiting;
            ScheduleDate = System.DateTime.Now.Date;
        }

        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate { get; set; }
        [Display(Name = "Status")]
        public string StatusText { get { return Status.ToString(); } }
        public RequestStatus Status { get; set; }

        [Key]
        public int ID { get; set; }
    }
}

