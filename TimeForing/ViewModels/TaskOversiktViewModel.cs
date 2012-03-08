using System;
using System.Collections.Generic;
using System.Linq;
using TimeForing.Common;
using TimeForing.Models;

namespace TimeForing.ViewModels
{
    public class TaskOversiktViewModel
    {
        private TimeforingRepository _repo;
        public List<DateTime> Dates { get; private set; }
        public List<Task> Tasks { get; private set; }
        // [dato,taskid] -> timer
        public Dictionary<String, Dictionary<int, double>> Timer { get; private set; }
        public User User { get; private set; }
        public string Week { get; private set; }

        public TaskOversiktViewModel(int userId, int week, int year)
        {
            Dictionary<String, Dictionary<int, double>> tmp = new Dictionary<string, Dictionary<int, double>>();

            _repo = new TimeforingRepository();
            User = _repo.GetUser(userId);


            Dates = Util.GenerateDates(week, year);
            GenerateTasks(week, year);


            foreach (var date in Dates)
            {
                if (!tmp.ContainsKey(date.ToString("ddMMyyyy")))
                    tmp.Add(date.ToString("ddMMyyyy"), new Dictionary<int, double>());
                var timeføringer = from t in User.HourRegs
                                   where t.Date == date
                                   select t;
                foreach (var timeføring in timeføringer)
                {
                    if (!tmp[date.ToString("ddMMyyyy")].ContainsKey(timeføring.Task.TaskID))
                        tmp[date.ToString("ddMMyyyy")][timeføring.Task.TaskID] = timeføring.TimeSpent;
                    else
                        tmp[date.ToString("ddMMyyyy")][timeføring.Task.TaskID] += timeføring.TimeSpent;
                }
            }
            Timer = tmp;
            

        }

        private void GenerateTasks(int week, int year)
        {
            var userTasks = _repo.GetUserWorkedOnTasksForWeek(User, week, year);
                            
            

            userTasks.Sort((t1, t2) => t1.Name.CompareTo(t2.Name));

            Tasks = new List<Task>();
            foreach (var item in userTasks)
            {
                if (Tasks.Contains(item))
                    continue;
                Tasks.Add(item);
            }
        }

    }
}
