using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TimeForing.Models;
using TimeForing.ViewModels;

namespace TimeForing.Controllers
{
    public class TaskController : Controller
    {

        TimeforingRepository repo = new TimeforingRepository();
        //
        // GET: /Task/

        public ActionResult Index()
        {

            return View(new TaskIndexViewModel(false));
        }

        //
        // POST: 7Task/

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string command, FormCollection collection)
        {
            bool showDoneTasks = collection["ShowDoneTasks"].Contains("true");
            return View(new TaskIndexViewModel(showDoneTasks));
        }
        

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View(new TaskFormViewModel(new Task()));
        }

        //
        // POST: /Task/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string command, FormCollection collection)
        {
            Task t = new Task();
            TaskFormViewModel tm = new TaskFormViewModel(t);
            try
            {
                UpdateModel(t);
                repo.AddTask(t);
                repo.Save();
                if (command == "save")
                    return RedirectToAction("Index");
                TaskFormViewModel tmNew = new TaskFormViewModel(new Task(), t.Sprint , t.User, t.Code, t.Story);
                ResetTextValues();

                return View(tmNew);

            }
            catch
            {
                ModelState.AddRuleViolations(t.GetRuleViolations());
                return View(new TaskFormViewModel(t));
            }
        }

        private void ResetTextValues()
        {
            ModelState["Name"].Value = new ValueProviderResult(null, string.Empty, CultureInfo.InvariantCulture);
            ModelState["Description"].Value = new ValueProviderResult(null, string.Empty, CultureInfo.InvariantCulture);
            ModelState["OrgEstimate"].Value = new ValueProviderResult(null, string.Empty, CultureInfo.InvariantCulture);
            ModelState["TimeLeft"].Value = new ValueProviderResult(null, string.Empty, CultureInfo.InvariantCulture);
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id)
        {
            return View(new TaskFormViewModel(repo.GetTask(id)));
        }

        //
        // POST: /Task/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, string command, FormCollection collection)
        {
            Task t = repo.GetTask(id);

            try
            {
                UpdateModel(t);
                repo.Save();
                if (command == "save")
                    return RedirectToAction("Index");
                TaskFormViewModel tm = new TaskFormViewModel(new Task(), t.Sprint, t.User, t.Code, t.Story);
                ResetTextValues();
                return View(tm);
            }
            catch
            {
                ModelState.AddRuleViolations(t.GetRuleViolations());
                return View(new TaskFormViewModel(t));
            }
        }
    }
}
