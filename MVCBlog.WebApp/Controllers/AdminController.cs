using MVCBlog.DAL;
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

		public ActionResult AdminAdd()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AdminAdd(string name, string username, string password, int status)
		{
			using BlogDBContext ctx = new BlogDBContext())
			{
				tblAdmins adminInfo = new tblAdmins();

				tblAdmins isAdmin = ctx.tblAdmins.Where(u => u.username == username).FirstOrDefault();

				if (isAdmin == null)
				{
					adminInfo.id = status;
					adminInfo.name = name;
					adminInfo.username = username;
					adminInfo.password = password;
					adminInfo.statusId = status;

					ctx.tblAdmins.Add(adminInfo);
					ctx.SaveChanges();

					ViewBag.Success = "Kayıt işlemi başarılı. :)";
				}
				else
				{
					ViewBag.Error = "Kullanıcı daha önce oluşturulmuş.";
				}
			}

			return View();
		}

		[HttpPost]
		public ActionResult Login(string username, string pass)
		{

			if (username == "admin" && pass == "123")
			{
				Session["Username"] = username;

				return RedirectToAction("Index", "Admin");
			}
			else
			{
				ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
				return View();
			}

		}
	}
}