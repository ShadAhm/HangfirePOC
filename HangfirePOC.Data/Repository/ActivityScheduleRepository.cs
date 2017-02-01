using HangfirePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; 
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Data.Repository
{
        public class ActivityScheduleRepository : IRepository<ActivitySchedule>
        {
            private HangfirePOC.Data.EDM.ActivitiesDB _dbContext;

            public ActivityScheduleRepository(HangfirePOC.Data.EDM.ActivitiesDB dbContext)
            {
                _dbContext = dbContext;
            }

            public void Add(ActivitySchedule newEntity)
            {
                _dbContext.ActivitiySchedules.Add(newEntity);
            }

            public List<ActivitySchedule> Find(Func<ActivitySchedule, bool> match)
            {
                return _dbContext.ActivitiySchedules.Where(match).ToList();
            }

            public List<ActivitySchedule> FindAll()
            {
                return _dbContext.ActivitiySchedules.AsNoTracking().ToList();
            }

            public void Remove(ActivitySchedule entity)
            {
                _dbContext.ActivitiySchedules.Remove(entity);
            }

            public void Update(ActivitySchedule entity)
            {
            }

            public ActivitySchedule FindByID(int id)
            {
                var results = _dbContext.ActivitiySchedules.Include(x => x.ActivityScheduleLines).Where(d => d.ID == id);

                return results.FirstOrDefault();
            }

            public void AddRange(List<ActivitySchedule> Drivers)
            {
                _dbContext.ActivitiySchedules.AddRange(Drivers);
            }
        }
    }
