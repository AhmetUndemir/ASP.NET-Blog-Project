using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Login()
		{
			return View();

		}

		[HttpPost]
		public ActionResult Login(string username, string pass)
		{

			if (username == "admin" && pass == "123")
			{
				Session["Username"] = username;

				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
				return View();
			}

		}
	}
}