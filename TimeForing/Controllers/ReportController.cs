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
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Report/Oversikt

        public ActionResult TimeOversikt()
        {
            TimeforingRepository repo = new TimeforingRepository ();
            ViewData["Users"] = SelectListMaker.Users();
            ViewData["Weeks"] = Util.GenerateWeekDropdown(DateTime.Today);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TimeOversikt(FormCollection collection)
        {
            int userId = int.Parse( collection["User"]);
            int weekNum = int.Parse ( collection["Week"]);
            TimeOversiktViewModel m = new TimeOversiktViewModel(userId, weekNum ,DateTime.Today.Year );
            return View("TimeOversiktRapport", m);
//            return null;
        }

        //
        // GET: /Report/TaskReport
        public ActionResult TaskReport()
        {
            TimeforingRepository repo = new TimeforingRepository();
            ViewData["Users"] = SelectListMaker.Users();
            ViewData["Weeks"] = Util.GenerateWeekDropdown(DateTime.Today);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TaskReport(FormCollection collection)
        {
            int userId = int.Parse(collection["User"]);
            int week = int.Parse(collection["Week"]);
            TaskOversiktViewModel m = new TaskOversiktViewModel(userId, week, DateTime.Today.Year );
            return View("TaskOversiktRapport", m);
        }

        //
        //Get /Report/Burndown
        public ActionResult Burndown()
        {
            TimeforingRepository repo = new TimeforingRepository();
            ViewData["Sprints"] = SelectListMaker.Sprints();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Burndown(FormCollection collection)
        {
           
            int sprintId = int.Parse(collection["Sprint"]);
            BurndownReportViewModel m = new BurndownReportViewModel(sprintId );
            return View("BurndownRapport", m);
        }

    }
}
