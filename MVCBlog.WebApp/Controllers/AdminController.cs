using MVCBlog.DAL;
using MVCBlog.WebApp.ModelView;
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
			using (BlogDBContexts ctx = new BlogDBContexts())
			{
				tblAdmins adminInfo = new tblAdmins();

				tblAdmins isAdmin = ctx.tblAdmins.Where(u => u.username == username).FirstOrDefault();

				if (isAdmin == null)
				{
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


		public ActionResult AdminList()
		{
			AdminListModel model = new AdminListModel();
			using (BlogDBContexts db = new BlogDBContexts())
			{
				//Çekilen verileri ToList() metoduyla List'e dönüştürdük.
				model.admins = db.tblAdmins.ToList();
			}
			return View(model);
			
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