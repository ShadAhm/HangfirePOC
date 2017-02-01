using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Model
{
    public class ActivitySchedule
    {
        [ForeignKey("Activity")]
        public int ActivityID { get; set; }
        [Display(Name = "Activity Name")]
        public string Name { get; set; }    
        [Key]
        public int ID { get; set; }
        public virtual Activity Activity { get; set; }

        public int RunType { get; set; } // 1 now 2 delay 3 interval

        public int DelayValue { get; set; }

        public int DelayType { get; set; } // 1 seconds 2 minutes 3 days

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RecurringScheduleType { get; set; }

        public DateTime? LastRun { get; set; }

        public virtual List<ActivityScheduleLine> ActivityScheduleLines { get; set; }
    }
}
