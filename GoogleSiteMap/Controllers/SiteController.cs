﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleSiteMap.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Site()
        {
            return View();
        }
    }
}
