using HangfirePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Data.Repository
{
        public class ActivityRepository : IRepository<Activity>
        {
            private HangfirePOC.Data.EDM.ActivitiesDB _dbContext;

            public ActivityRepository(HangfirePOC.Data.EDM.ActivitiesDB dbContext)
            {
                _dbContext = dbContext;
                if (_dbContext.ActivitiySchedules.Count() == 0)
                {
                    AddRange(GetMockActivitiyScheduleData());
                    _dbContext.SaveChanges();
                }
            }

            private List<Activity> GetMockActivitiyScheduleData()
            {
                return new List<Activity>() {
                };
            }

            public void Add(Activity newEntity)
            {
                _dbContext.Activities.Add(newEntity);
            }

            public List<Activity> Find(Func<Activity, bool> match)
            {
                return _dbContext.Activities.Where(match).ToList();
            }

            public List<Activity> FindAll()
            {
                return _dbContext.Activities.ToList();
            }

            public void Remove(Activity entity)
            {
                _dbContext.Activities.Remove(entity);
            }

            public void Update(Activity entity)
            {
            }

            public Activity FindByID(int id)
            {
                var results = _dbContext.Activities.Where(d => d.ID == id);

                return results.FirstOrDefault();
            }

            public void AddRange(List<Activity> activities)
            {
                _dbContext.Activities.AddRange(activities);
            }
        }
    }
