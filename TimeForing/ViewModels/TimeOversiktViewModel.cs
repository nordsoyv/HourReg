using System;
using System.Collections.Generic;
using System.Linq;
using TimeForing.Common;
using TimeForing.Models;

namespace TimeForing.ViewModels
{
    public class TimeOversiktViewModel
    {
        public List<DateTime> Dates { get; private set; }
        public List<String> Tasks { get; private set; }
        public Dictionary<String, Dictionary<String, double>> Timer { get; private set; }
        public User User { get; private set; }
        public string Week { get; private set; }

        private TimeforingRepository _repo;

        public TimeOversiktViewModel(int userId, int weekNum, int year)
        {
            Dictionary<String, Dictionary<String, double>> tmp = new Dictionary<string, Dictionary<String, double>>();
            _repo = new TimeforingRepository();

            User = _repo.GetUser(userId);
            Week = weekNum.ToString();
            Dates = Util.GenerateDates(weekNum, year);
            GenerateTasks(weekNum, year);

            foreach (var date in Dates)
            {
                if (!tmp.ContainsKey(date.ToString("ddMMyyyy")))
                    tmp.Add(date.ToString("ddMMyyyy"), new Dictionary<String, double>());
                var timeføringer = User.HourRegs.Where(t => t.Date == date);
                foreach (var timeføring in timeføringer)
                {
                    if (!tmp[date.ToString("ddMMyyyy")].ContainsKey(timeføring.Task.Code.GetProjectAndCodenumber()))
                        tmp[date.ToString("ddMMyyyy")][timeføring.Task.Code.GetProjectAndCodenumber()] = timeføring.TimeSpent;
                    else
                        tmp[date.ToString("ddMMyyyy")][timeføring.Task.Code.GetProjectAndCodenumber()] += timeføring.TimeSpent;
                }
            }
            Timer = tmp;
        }

        private void GenerateTasks(int week, int year)
        {

            var userTasks = _repo.GetUserWorkedOnTasksForWeek(User, week, year);
            userTasks.Sort((t1, t2) => t1.Code.GetProjectAndCodenumber().CompareTo(t2.Code.GetProjectAndCodenumber()));
            Tasks = new List<String>();
            foreach (var item in userTasks)
            {
                string c = item.Code.ProjectID + "/" + item.Code.CodeNumber;
                if (Tasks.Contains(c))
                    continue;
                Tasks.Add(c);
            }
        }


    }
}
