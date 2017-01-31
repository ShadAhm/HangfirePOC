using HangfirePOC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangfirePOC.Service
{
    public interface IActivityService
    {
        void RunActivity(int activityId);
    }
    
    public class ActivityService : IActivityService
    {
        private IUnitOfWork _uof;

        public ActivityService()
        : this(new UnitOfWork()){ }

        public ActivityService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public void RunActivity(int activityId)
        {
            Thread.Sleep(5000);

            var af = _uof.ActivityScheduleRepo.FindByID(activityId);
            af.LastRun = DateTime.Now;

            _uof.ActivityScheduleRepo.Update(af);
            _uof.SaveChanges();
        }
    }
}
