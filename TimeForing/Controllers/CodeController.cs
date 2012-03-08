using System.Linq;
using System.Web.Mvc;
using TimeForing.Models;
using TimeForing.ViewModels;

namespace TimeForing.Controllers
{
    public class CodeController : Controller
    {
        //
        // GET: /Code/

        TimeforingRepository repo = new TimeforingRepository();

        public ActionResult Index()
        {
            var c = repo.FindAllCodes().ToList();
            return View(c);
        }

        //
        // GET: /Code/Create

        public ActionResult Create()
        {
            Code c =  new Code();
            CodeFormViewModel v = new CodeFormViewModel(c);
            return View(v);
        } 

        //
        // POST: /Code/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {

            Code  c = new Code();
            try
            {
                UpdateModel(c);
                repo.AddCode(c );
                repo.Save();
               

                return RedirectToAction("Index");
            }
            catch (System.Data.SqlClient.SqlException )
            {
                ModelState.AddModelError("ProjectID", "Prosjektnummer finnes ikke");
                return View(c);
            }

            catch
            {
                ModelState.AddRuleViolations(c .GetRuleViolations());
                return View(c);
            }
        }

        //
        // GET: /Code/Edit/5
 
        public ActionResult Edit(int id)
        {
            Code c = repo.GetCode(id);
            CodeFormViewModel v = new CodeFormViewModel(c);
            return View(v);
        }

        //
        // POST: /Code/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Code c = repo.GetCode(id);
            CodeFormViewModel v = new CodeFormViewModel(c);
            try
            {
                UpdateModel(c);
                repo.Save();
               
 
                return RedirectToAction("Index");
            }
            catch (System.Data.SqlClient.SqlException )
            {
                ModelState.AddModelError("ProjectID", "Prosjektnummer finnes ikke");
                return View(new CodeFormViewModel(c));
            }

            catch
            {
                ModelState.AddRuleViolations(v.Code .GetRuleViolations());
                return View(new CodeFormViewModel (c));
            }
        }
    }
}
