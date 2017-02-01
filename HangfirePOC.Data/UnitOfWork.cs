using HangfirePOC.Data.Repository;
using HangfirePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Data
{
    public interface IUnitOfWork
    {
        IRepository<ActivitySchedule> ActivityScheduleRepo { get; }
        IRepository<ActivityScheduleLine> ActivityScheduleLineRepo { get; }
        IRepository<Activity> ActivityRepo { get; }

        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<ActivitySchedule> _activityScheduleRepo;
        private IRepository<ActivityScheduleLine> _activityScheduleLineRepo;
        private IRepository<Activity> _activityRepo;

        private EDM.ActivitiesDB _dbContext;

        public UnitOfWork()
        {
            _dbContext = new EDM.ActivitiesDB();
            _activityScheduleRepo = new ActivityScheduleRepository(_dbContext);
            _activityScheduleLineRepo = new ActivityScheduleLineRepository(_dbContext);
            _activityRepo = new ActivityRepository(_dbContext);
        }

        public IRepository<ActivitySchedule> ActivityScheduleRepo
        {
            get
            {
                return _activityScheduleRepo;
            }
        }

        public IRepository<ActivityScheduleLine> ActivityScheduleLineRepo
        {
            get
            {
                return _activityScheduleLineRepo;
            }
        }

        public IRepository<Activity> ActivityRepo
        {
            get
            {
                return _activityRepo;
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
