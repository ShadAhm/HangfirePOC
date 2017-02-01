using HangfirePOC.Data;
using HangfirePOC.Model;
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
        void RunRecurringActivity(int activityId);
        void RunDelayedActivity(int activityId);
    }

    public class ActivityService : IActivityService
    {
        private IUnitOfWork _uof;

        public ActivityService()
        : this(new UnitOfWork()) { }

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

            AddScheduleLine(activityId, af.CreatedOn, af.LastRun.GetValueOrDefault());
        }

        public void RunRecurringActivity(int activityId)
        {
            var af = _uof.ActivityScheduleRepo.FindByID(activityId);
            af.LastRun = DateTime.Now;

            _uof.ActivityScheduleRepo.Update(af);
            _uof.SaveChanges();

            AddScheduleLine(activityId, af.CreatedOn, af.LastRun.GetValueOrDefault());
        }

        public void RunDelayedActivity(int activityId)
        {
            var af = _uof.ActivityScheduleRepo.FindByID(activityId);
            af.LastRun = DateTime.Now;

            _uof.ActivityScheduleRepo.Update(af);
            _uof.SaveChanges();

            AddScheduleLine(activityId, af.CreatedOn, af.LastRun.GetValueOrDefault());
        }

        private int AddScheduleLine(int activityScheduleId, DateTime requestDate, DateTime scheduleDate)
        {
            ActivityScheduleLine scheduleLine = new ActivityScheduleLine();

            scheduleLine.ActivityScheduleID = activityScheduleId; 
            scheduleLine.RequestDate = requestDate;
            scheduleLine.ScheduleDate = scheduleDate;
            scheduleLine.Status = RequestStatus.Complete;

            _uof.ActivityScheduleLineRepo.Add(scheduleLine);
            _uof.SaveChanges();

            return scheduleLine.ID;
        }
    }
}
