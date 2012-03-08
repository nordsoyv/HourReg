using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TimeForing.Models;

namespace TimeForing.Controllers
{
    public class UserController : Controller
    {
        TimeforingRepository repo = new TimeforingRepository();

        //
        // GET: /User/

        public ActionResult Index()
        {
            var u = repo.FindAllUsers().ToList ();
            return View(u);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View(new User());
        } 

        //
        // POST: /User/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            User u = new User();
            try
            {
                UpdateModel(u);
                repo.AddUser(u);
                repo.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddRuleViolations(u.GetRuleViolations());
                return View(u);
            }
        }

        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            User u = repo.GetUser(id);
            return View(u);
        }

        //
        // POST: /User/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            User u = repo.GetUser(id);
            try
            {
                UpdateModel(u);
                repo.Save();
        
                return RedirectToAction("Index");
            }
            catch (System.Data.SqlClient.SqlException )
            {
                ModelState.AddModelError("ProjectID", "Prosjektnummer finnes ikke");
                return View(u);
            }

            catch
            {
                ModelState.AddRuleViolations(u.GetRuleViolations());
                return View(u);
            }
        }
    }
}
