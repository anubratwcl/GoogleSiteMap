using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using GoogleSiteMap.Services;
using System.Web.Routing;
using System.IO;
using System.Xml;
using System.Text;


namespace GoogleSiteMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISitemapService sitemapService;
        //private readonly RequestContext context;
        #region Constructors

        public HomeController(ISitemapService sitemapService)
        {
            this.sitemapService = sitemapService;
        }
        public HomeController():this(new SitemapService(new CacheService(), new UrlHelper(new RequestContext()))) 
           {
              
        }        
        #endregion
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CreateGoogleSiteMap()
        {           

            return View();
        }
        [HttpPost]        
        public ActionResult CreateSiteMap()
        {  
           
            string content = this.sitemapService.GetSitemapXml();
            if (content == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sitemap index is out of range.");
            }
           //StringBuilder UptoMain = new StringBuilder();
           //UptoMain.AppendLine(content);
            using (StreamWriter file = new StreamWriter(@"C:\D\Anup\w2b2b\GoogleSitemapProject\GoogleSiteMap\GoogleSiteMap\sitemap.xml", false))
           {
               file.WriteLine(content);
           }
            return View("CreateGoogleSiteMap");
        }
    }
}
