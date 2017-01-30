using HangfirePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC.Data.Repository
{
        public class OptimizationRequestRepository : IRepository<OptimizationRequest>
        {
            private HangfirePOC.Data.EDM.ActivitiesDB _dbContext;

            public OptimizationRequestRepository(HangfirePOC.Data.EDM.ActivitiesDB dbContext)
            {
                _dbContext = dbContext;
            }

            public void Add(OptimizationRequest newEntity)
            {
                _dbContext.OptimizationRequests.Add(newEntity);
            }

            public List<OptimizationRequest> Find(Func<OptimizationRequest, bool> match)
            {
                return _dbContext.OptimizationRequests.Where(match).ToList();
            }

            public List<OptimizationRequest> FindAll()
            {
                return _dbContext.OptimizationRequests.ToList();
            }

            public void Remove(OptimizationRequest entity)
            {
                _dbContext.OptimizationRequests.Remove(entity);
            }

            public void Update(OptimizationRequest entity)
            {
            }

            public OptimizationRequest FindByID(int id)
            {
                var results = _dbContext.OptimizationRequests.Where(d => d.ID == id);

                return results.FirstOrDefault();
            }

            public void AddRange(List<OptimizationRequest> Drivers)
            {
                _dbContext.OptimizationRequests.AddRange(Drivers);
            }
        }
    }
