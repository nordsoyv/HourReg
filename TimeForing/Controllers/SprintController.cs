using System.Linq;
using System.Web.Mvc;
using TimeForing.Models;
using TimeForing.ViewModels;

namespace TimeForing.Controllers
{
    public class SprintController : Controller
    {
        TimeforingRepository repo = new TimeforingRepository();

        //
        // GET: /Sprint/

        public ActionResult Index()
        {
            var s = repo.FindAllSprints().ToList();
            return View(s);
        }


        //
        // GET: /Sprint/Create

        public ActionResult Create()
        {
            return View(new Sprint());
        }

        //
        // POST: /Sprint/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Sprint s = new Sprint();
            try
            {
                UpdateModel(s);
                repo.AddSprint(s);
                repo.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(s);
            }
        }

        
        //
        // GET: /Sprint/Edit/5

        public ActionResult Edit(int id)
        {
            return View(repo.GetSprint(id));
        }

        //
        // POST: /Sprint/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Sprint s = repo.GetSprint(id);
            try
            {
                UpdateModel(s);
                repo.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddRuleViolations(s.GetRuleViolations());
                return View(s);
            }
        }

        //
        // GET: /Sprint/SelectTasks/5
        public ActionResult SelectTasks(int id)
        {
            SelectTasksViewModel model = new SelectTasksViewModel(id);
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SelectTasks(int id, FormCollection collection)
        {
            var tasks = repo.GetTasksInSprint(id);
            string[] sprinter = collection.GetValues ("SprintId");
            string[] users  = collection.GetValues ("UserID");
             
            


            for (int i = 0; i<sprinter.Count (); i++)
            {
                tasks[i].SprintID = int.Parse(sprinter[i]);
            }


            for (int i = 0; i < users .Count (); i++)
            {
                tasks[i].UserID = int.Parse(users[i]);
            }



            repo.Save();

            return RedirectToAction("Index");
        }
    }
}
