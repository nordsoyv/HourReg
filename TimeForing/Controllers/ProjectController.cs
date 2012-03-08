using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TimeForing.Models;

namespace TimeForing.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        private TimeforingRepository repo = new TimeforingRepository();

        public ActionResult Index()
        {
            var p = repo.FindAllProjects().ToList();
            return View(p);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            Project p = new Project();
            return View(p);
        }

        //
        // POST: /Project/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Project p = new Project();

            try
            {
                UpdateModel(p);
                repo.AddProject(p);
                repo.Save();
                return RedirectToAction("Index");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ModelState.AddModelError("ProjectID", "Prosjektnummer allerede i bruk");
                return View(p);
            }
            catch
            {
                ModelState.AddRuleViolations(p.GetRuleViolations());
                return View(p);
            }
        }

        //
        // GET: /Project/Edit/5

        public ActionResult Edit(int id)
        {
            Project p = repo.GetProject(id);

            return View(p);
        }

        //
        // POST: /Project/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Project p = repo.GetProject(id);
            try
            {

                UpdateModel(p);
                repo.Save();

                return RedirectToAction("Index");
            }
            catch (System.InvalidOperationException ) 
            {
                ModelState.AddModelError("ProjectID", "Prosjektnummer allerede i bruk");
                return View(p);
            }
            catch
            {
                ModelState.AddRuleViolations(p.GetRuleViolations());
                return View(p);
            }
        }
    }
}
