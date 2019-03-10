using MVCBlog.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.WebApp.ModelView
{
	public class AdminListModel
	{
		public List<tblAdmins> admins { get; set; }
		public tblStatus status { get; set; }
		public tblAdmins admin { get; set; }
	}
}