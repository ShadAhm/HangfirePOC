using Hangfire;
using HangfirePOC.Data;
using HangfirePOC.Model;
using HangfirePOC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HangfirePOC.Controllers
{
    public class ScheduleController : Controller
    {
        private IUnitOfWork _uof;
        private IActivityService _activityService; 

        public ScheduleController(IUnitOfWork uof, IActivityService activityService)
        {
            _uof = uof;
            _activityService = activityService;
        }

        [OutputCache(Duration = 0)]
        public ActionResult Index()
        {
            var schedules = _uof.ActivityScheduleRepo.FindAll();

            return View(schedules);
        }

        public ActionResult Detail(int id)
        {
            var schedule = _uof.ActivityScheduleRepo.FindByID(id);

            return View("Detail", schedule); 
        }

        public ActionResult Create(string activityId)
        {
            int activityIdInt = 0;

            ViewBag.NowOrDelay = new SelectList(
                new List<object>
                {
                    new { Id = 1, Name = "Now" },
                    new { Id = 2, Name = "Later" },
                    new { Id = 3, Name = "By intervals" }
                }
                , "Id", "Name", "1");

            ViewBag.DelayType = new SelectList(
                new List<object>
                {
                    new { Id = 1, Name = "Seconds" },
                    new { Id = 2, Name = "Minutes" },
                    new { Id = 3, Name = "Days" }
                }
                , "Id", "Name", "1");

            ViewBag.RecurringScheduleType = new SelectList(
                new List<object>
                {
                    new { Id = 1, Name = "Daily" },
                    new { Id = 2, Name = "Hourly" },
                    new { Id = 3, Name = "Minutely" },
                    new { Id = 4, Name = "Monthly" },
                    new { Id = 5, Name = "Weekly" },
                    new { Id = 6, Name = "Yearly" }
                }
                , "Id", "Name", "1");

            if (int.TryParse(activityId, out activityIdInt))
            {
                return View("Create", new ActivitySchedule { ActivityID = activityIdInt });
            }
            else
            {
                return View("Create");
            }
        }

        [HttpPost]
        public ActionResult Create(ActivitySchedule newSchedule)
        {
            if (ModelState.IsValid)
            {
                string description = "";

                switch (newSchedule.RunType)
                {
                    case 1:
                        description = "Set to run immediately";
                        break;
                    case 2:
                        description = string.Format("Set to run after {0} {1}", newSchedule.DelayValue, newSchedule.DelayType == 1 ? "seconds" : newSchedule.DelayType == 2 ? "minutes" : "days");
                        break;
                    case 3:
                        description = "Set to run on intervals";
                        break;
                }

                newSchedule.Description = description; 
                newSchedule.CreatedOn = DateTime.Now;

                _uof.ActivityScheduleRepo.Add(newSchedule);
                _uof.SaveChanges();

                switch (newSchedule.RunType)
                {
                    case 1:
                        FireAndForgetJob(newSchedule.ID);
                        break;
                    case 2:
                        ScheduleDelayedJobs(newSchedule.ID, newSchedule.DelayValue, newSchedule.DelayType);
                        break;
                    case 3:
                        ScheduleRecurringJob(newSchedule.ID, newSchedule.RecurringScheduleType);
                        break;
                }

                return RedirectToAction("Index");
            }

            return View(newSchedule);
        }

        private void ScheduleDelayedJobs(int scheduleId, int delayUnit, int delayType)
        {
            TimeSpan ts = TimeSpan.FromSeconds(delayUnit); 

            switch(delayType)
            {
                case 2: ts = TimeSpan.FromMinutes(delayUnit);
                    break;
                case 3: ts = TimeSpan.FromDays(delayUnit);
                    break; 
            }

            BackgroundJob.Schedule(() => _activityService.RunDelayedActivity(scheduleId), ts);
        }

        private void ScheduleRecurringJob(int scheduleId, int recurringScheduleType)
        {
            RecurringJob.AddOrUpdate(() => _activityService.RunRecurringActivity(scheduleId)
            , GetCronFromRecurringType(recurringScheduleType));
        }

        private void FireAndForgetJob(int scheduleId)
        {
            var id = BackgroundJob.Enqueue(() => _activityService.RunActivity(scheduleId));
        }

        private Func<string> GetCronFromRecurringType(int recurringSchedule)
        {
            switch (recurringSchedule)
            {
                case 1:
                    return Cron.Daily;
                case 2:
                    return Cron.Hourly;
                case 3:
                    return Cron.Minutely;
                case 4:
                    return Cron.Monthly;
                case 5:
                    return Cron.Weekly;
                case 6:
                    return Cron.Yearly;
                default:
                    return Cron.Daily;
            }
        }
    }
}