using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Header = "_homePartial";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.HeaderTitle = "About Me";
            ViewBag.Header = "_secondaryHeader";
            return View();
        }

        [HttpGet]
        public FileResult DownloadResume()
        {
            string filePath = Server.MapPath("~/Downloads/DylanBelcherResume.doc");
            return File(filePath, "application/docx", Server.UrlEncode("~/Downloads/DylanBelcherResume.doc"));
        }

        [HttpGet]
        public FileResult DownloadCoverLetter()
        {
            string filePath = Server.MapPath("~/Downloads/CoverLetter.docx");
            return File(filePath, "application/docx", Server.UrlEncode("~/Downloads/CoverLetter.docx"));
        }
    }
}
