using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TimeForing.Common;
using TimeForing.Models;
using TimeForing.ViewModels;

namespace TimeForing.Controllers
{
    public class TimeRegController : Controller
    {
        //
        // GET: /TimeReg/

        public ActionResult Index(string user, string week)
        {
            int userId;
            int weekNum;
            int.TryParse(user, out userId);
            int.TryParse(week, out weekNum);

            TimeRegViewModel model = new TimeRegViewModel(userId, weekNum,DateTime.Today );

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int user,string command, FormCollection collection)
        {
            TimeRegViewModel model;
            DateTime selectedDate = DateTime.Parse(collection["Date"]);
            int week = Util.WeekInYear(selectedDate);
            TimeforingRepository repo = new TimeforingRepository();
            //string command = collection["command"];
            bool showDoneTasks = collection["ShowDoneTasks"].Contains("true");


            if (command == "update" )
            {
                model = new TimeRegViewModel(user, week, selectedDate, "Oppdatert",showDoneTasks );
                return View(model);
            }
            else //save
            {
                Task currTask;
                string[] timerBrukt = collection.GetValues("TimerBrukt");

                string[] timerIgjen = collection.GetValues("TimerIgjen");
                string[] taskIds = collection.GetValues("TaskId");

                //var userDateRegs = repo.GetHourRegsForUserDateSprint (user,d,sprint );
                var userDateRegs = repo.GetHourRegs().Where(r => r.User.UserID == user && r.Date == selectedDate).Select(r => r);
                if (userDateRegs.Count() > 0) // skal oppdatere
                {

                    for (int i = 0; i < taskIds.Count(); i++)
                    {
                        int taskId = int.Parse(taskIds[i]);
                        var currHourReg = from h in userDateRegs
                                          where h.TaskID == taskId
                                          select h;

                        currTask = repo.GetTask(taskId);
                        HourReg hourReg;
                        if (currHourReg.Count() > 0)
                        { //update
                            hourReg = currHourReg.ToList().ElementAt(0);
                        }
                        else
                        { // new
                            hourReg = new HourReg();
                        }
                        hourReg.Date = selectedDate;
                        hourReg.SprintID = (int)currTask.SprintID;
                        hourReg.TaskID = currTask.TaskID;
                        hourReg.TimeLeft = Double.Parse(timerIgjen[i]);
                        hourReg.TimeSpent = Double.Parse(timerBrukt[i]);
                        hourReg.UserID = user;

                        currTask.TimeLeft = Double.Parse(timerIgjen[i]);

                        if (currHourReg.Count() == 0) //new
                            repo.AddHourReg(hourReg);
                    }
                }
                else
                {

                    for (int i = 0; i < taskIds.Count(); i++)
                    {
                        int taskId = int.Parse(taskIds[i]);
                        currTask = repo.GetTask(taskId);
                        HourReg h = new HourReg();
                        h.Date = selectedDate;
                        h.SprintID = (int)currTask.SprintID;
                        h.TaskID = currTask.TaskID;
                        h.TimeLeft = Double.Parse(timerIgjen[i]);
                        h.TimeSpent = Double.Parse(timerBrukt[i]);
                        h.UserID = user;
                        currTask.TimeLeft = Double.Parse(timerIgjen[i]);
                        repo.AddHourReg(h);
                    }
                }
                repo.Save();

            }
            model = new TimeRegViewModel(user, week, selectedDate, "Lagret",showDoneTasks );
            return View(model);

        }


    }
}
