using System;
using System.Collections.Generic;
using System.Linq;
using TimeForing.Models;

namespace TimeForing.ViewModels
{
    public class BurndownReportViewModel
    {
        public List<DateTime> Dates { get; private set; }
        public List<double> Timer { get; private set; }
        public double OrgTimer { get; private set; }
        public Sprint Sprint { get; private set; }

        public BurndownReportViewModel(int sprintId)
        {
            TimeforingRepository repo = new TimeforingRepository();
            Sprint = repo.GetSprint(sprintId);
            GenerateDates();

            var org = from t in Sprint.Tasks
                         select t.OrgEstimate;
            OrgTimer = (double)org.Sum();

            Timer = new List<double>();

            foreach (var date in Dates )
            {
                var hourRegs = from h in Sprint.HourRegs
                               where h.Date.Equals(date)
                               select h;
                var startedTasksIDs = hourRegs.Select(p => p.TaskID);
                var nonStartedTasks = from t in Sprint.Tasks
                                      where !startedTasksIDs.Contains(t.TaskID)
                                      select t;
                var timerIgjen = from t in hourRegs
                                 select t.TimeLeft;
                if (timerIgjen.Count() != 0)
                {
                    double timerHourRegs = timerIgjen.Sum();
                    double unstartedTimer = nonStartedTasks.Sum(p => p.TimeLeft ?? 0);
                    Timer.Add(timerHourRegs + unstartedTimer);
                }
                else
                {
                    Timer.Add(0);
                }
            }


        }
        
        private void GenerateDates()
        {
            Dates = new List<DateTime>();
            if (Sprint.StartDate != null && Sprint.EndDate != null)
            {
                for (DateTime d = (DateTime)Sprint.StartDate; d <= Sprint.EndDate; d = d.AddDays(1))
                {
                    Dates.Add(d);
                }
            }
        }

    }
}
