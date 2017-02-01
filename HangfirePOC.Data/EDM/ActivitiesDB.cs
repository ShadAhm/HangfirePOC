using HangfirePOC.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Data.EDM
{
    public class ActivitiesDB : DbContext
    {
        public ActivitiesDB() : base("name=ActivitiesDB") 
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivitySchedule> ActivitiySchedules { get; set; }
        public virtual DbSet<ActivityScheduleLine> ActivityScheduleLines { get; set; }

    }
}
