using System;
using System.Web;
using System.Web.Mvc;
using TimeForing.ViewModels;

namespace TimeForing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View(new IndexViewModel());
        }



        //
        // Post /Home/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection collection)
        {
            string user = collection["SelectedUser"];
            string week = collection["Weeks"];
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["TimeRegUser"];
            if (cookie  == null)
            {
                cookie = new HttpCookie("TimeRegUser");
            }
            cookie.Value = user;
            cookie.Expires = DateTime.Now.AddMonths(1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "TimeReg", new { user = user.ToString(), week = week });

        }

        //
        // GET: /Home/
        public ActionResult Settings()
        {
            return View();
        }

    }
}
