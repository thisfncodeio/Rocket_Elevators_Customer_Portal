﻿using System.Web;
using System.Web.Mvc;

namespace Rocket_Elevators_Customer_Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
