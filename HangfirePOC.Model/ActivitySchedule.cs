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
        [ForeignKey("OptimizationRequest")]
        public int OptimizationRequestID { get; set; }

        [ForeignKey("Activity")]
        public int ActivityID { get; set; }
        [Display(Name = "Activity Name")]
        public string Name { get; set; }

        [Key]
        public int ID { get; set; }

        public virtual OptimizationRequest OptimizationRequest { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
