using System;
using System.Collections.Generic;
using TimeForing.Common;
using TimeForing.Models;
using System.Web.Mvc;

namespace TimeForing.ViewModels
{
	public class IndexViewModel
	{
		public List<SelectListItem> Users { get; private set; }
		public SelectList Weeks { get; private set; }

		public IndexViewModel()
		{
			TimeforingRepository repo = new TimeforingRepository();
			var ctx = System.Web.HttpContext.Current;
			var c = ctx.Request.Cookies["TimeRegUser"];

			if (c != null)
			{
				int userId;
				if (int.TryParse(c.Value, out userId))
				{
					User last = repo.GetUser(int.Parse(c.Value));
					Users = SelectListMaker.UsersWithSelected(last);
				}
				else
				{
					Users = SelectListMaker.Users();
				}

			}
			else
			{
				Users = SelectListMaker.Users();
			}
			Weeks = Util.GenerateWeekDropdown(DateTime.Today);

		}
	}
}