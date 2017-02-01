using HangfirePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Data.Repository
{
        public class ActivityScheduleLineRepository : IRepository<ActivityScheduleLine>
        {
            private HangfirePOC.Data.EDM.ActivitiesDB _dbContext;

            public ActivityScheduleLineRepository(HangfirePOC.Data.EDM.ActivitiesDB dbContext)
            {
                _dbContext = dbContext;
            }

            public void Add(ActivityScheduleLine newEntity)
            {
                _dbContext.ActivityScheduleLines.Add(newEntity);
            }

            public List<ActivityScheduleLine> Find(Func<ActivityScheduleLine, bool> match)
            {
                return _dbContext.ActivityScheduleLines.Where(match).ToList();
            }

            public List<ActivityScheduleLine> FindAll()
            {
                return _dbContext.ActivityScheduleLines.ToList();
            }

            public void Remove(ActivityScheduleLine entity)
            {
                _dbContext.ActivityScheduleLines.Remove(entity);
            }

            public void Update(ActivityScheduleLine entity)
            {
            }

            public ActivityScheduleLine FindByID(int id)
            {
                var results = _dbContext.ActivityScheduleLines.Where(d => d.ID == id);

                return results.FirstOrDefault();
            }

            public void AddRange(List<ActivityScheduleLine> Drivers)
            {
                _dbContext.ActivityScheduleLines.AddRange(Drivers);
            }
        }
    }
