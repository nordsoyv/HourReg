using System.Web.Mvc;
using TimeForing.Models;
using TimeForing.ViewModels;

namespace TimeForing.Controllers
{
    public class StoriesController : Controller
    {
        //
        // GET: /Stories/
        private TimeforingRepository repo = new TimeforingRepository();
        public ActionResult Index()
        {
            var s = repo.FindAllStories();
            return View(s);
        }



        //
        // GET: /Stories/Create

        public ActionResult Create()
        {
            Story s = new Story();
            StoriesViewModel m = new StoriesViewModel(s);
            return View(m);
        }

        //
        // GET: /Stories/AddTasks
        public ActionResult AddTasks(int id)
        {
            Story s = new Story();
            StoriesViewModel m = new StoriesViewModel(s);
            return View(m);
        }

        //
        // POST: /Stories/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Story s = new Story();
          
            try
            {
                UpdateModel(s);
                repo.AddStory(s);
                repo.Save();


                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddRuleViolations(s.GetRuleViolations());
                return View(new  StoriesViewModel(s));
            }
        }

        //
        // GET: /Stories/Edit/5

        public ActionResult Edit(int id)
        {
            Story s = repo.GetStory(id);
            StoriesViewModel m = new StoriesViewModel(s);
            return View(m);
        }

        //
        // POST: /Stories/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Story s = repo.GetStory(id);
            try
            {
                // TODO: Add update logic here
                UpdateModel (s);
                repo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddRuleViolations(s.GetRuleViolations());
                return View(new StoriesViewModel (s));
          
            }
        }
    }
}
