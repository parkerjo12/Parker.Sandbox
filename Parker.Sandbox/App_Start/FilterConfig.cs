﻿using System.Web;
using System.Web.Mvc;

namespace Parker.Sandbox
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
