using System;
using System.Collections.Generic;
using System.Linq;
using TimeForing.Common;
using TimeForing.Models;
using System.Web.Mvc;

namespace TimeForing.ViewModels
{
    public class TimeRegViewModel
    {
        public List<Task> Tasks { get; private set; }
        public List<double> HourSpent { get; private set; }
        public User User { get; private set; }
        public List<SelectListItem> Dates { get; private set; }
        public String Message { get; private set; }
        public String Week { get; private set; }
        public Boolean ShowDoneTasks { get; private set; }


        private TimeforingRepository _repo;
        private DateTime _startDate;
        private DateTime _endDate;


        public TimeRegViewModel(int user, int week)
        {
            InitClass(user, week, Util.StartDateInWeek(week, DateTime.Today.Year), "", false);
        }



        public TimeRegViewModel(int user, int week, DateTime date)
        {
            InitClass(user, week, date, "",false);
        }

        public TimeRegViewModel(int user, int week, DateTime date, string mess)
        {
            InitClass(user, week, date, mess,false);
        }

        public TimeRegViewModel(int user, int week, DateTime date, string mess,bool showDoneTasks)
        {
            InitClass(user, week, date, mess, showDoneTasks );
        }

        private void InitClass(int user, int week, DateTime date, string mess,bool showDoneTasks)
        {
            _repo = new TimeforingRepository();
            User = _repo.GetUser(user);
            Week = week.ToString();
            ShowDoneTasks = showDoneTasks; 
            GenerateDatesInWeek(week, date);
            SetupTasks(user);
            FindHoursSpent(date);
            Message = mess;
            
        }

        private void SetupTasks(int user)
        {
            var allSprints = _repo.FindAllActiveSprints();
            var activeSprints = from s in allSprints
                                where s.StartDate <= _startDate //&& s.EndDate >= _endDate
                                select s.SprintID;
            var allTasks = _repo.FindAllTasks();
            var userTask = from t in allTasks
                           where t.UserID == user
                           select t;

            var activeTasks = userTask.Where(t => activeSprints.Contains((int)t.SprintID)).Select(t => t).ToList();
            if(!ShowDoneTasks )
                Tasks = activeTasks.Where(t => t.TimeLeft > 0).Select(t => t).ToList();
            else
            {
                Tasks = activeTasks.ToList();            
            }
            Tasks.Sort((t1, t2) => t1.Name.CompareTo(t2.Name));
        }

        private void FindHoursSpent(DateTime currDate)
        {
            HourSpent = new List<double>();
            var regs = _repo.GetHourRegs().Where(r => r.User == User && r.Date == currDate).Select(r => r);
            //                    var regs = _repo.GetHourRegsForUserDateSprint(User.UserID, currDate,Sprint .SprintID );
            foreach (var task in Tasks)
            {
                var reg = from r in regs
                          where r.TaskID == task.TaskID
                          select r;
                if (reg.Count() > 0)
                    HourSpent.Add(reg.ToList().ElementAt(0).TimeSpent);
                else
                    HourSpent.Add(0);
            }

        }

        private void GenerateDatesInWeek(int week, DateTime selected )
        {
            _startDate = Util.StartDateInWeek(week, DateTime.Today.Year);
            _endDate = _startDate.AddDays(6);
            Dates = new List<SelectListItem>();
            for (DateTime d = _startDate; d <= _endDate; d = d.AddDays(1))
            {
                SelectListItem s = new SelectListItem();
                s.Text = d.ToString("dd.MM.yyyy");
                if (d == selected)
                    s.Selected = true;
                Dates.Add(s);
            }

        }

    }
}