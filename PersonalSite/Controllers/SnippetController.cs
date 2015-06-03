using PersonalSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalSite.Controllers
{
    public class SnippetController : Controller
    {
        private SnippetContext db = new SnippetContext();

        public ActionResult Index()
        {
            return View(db.AllSnippets.ToList());
        }

        public ActionResult ViewSnippet(int id)
        {
            return View(db.AllSnippets.Find(id));
        }

        public ActionResult CSharp()
        {
            var CSharpSnippets = (from snippet in db.AllSnippets
                                  where snippet.Language == Language.CSharp
                                  select snippet).ToList();
            return View(CSharpSnippets);
        }

        public ActionResult ObjC()
        {
            var ObjCSnippets = (from snippet in db.AllSnippets
                                where snippet.Language == Language.ObjC
                                select snippet).ToList();
            return View(ObjCSnippets);
        }

        public ActionResult Swift()
        {
            var SwiftSnippets = (from snippet in db.AllSnippets
                                 where snippet.Language == Language.Swift
                                 select snippet).ToList();
            return View(SwiftSnippets);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Post a Snippet";
            ViewBag.Header = "_secondaryHeader";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            return RedirectToAction("Index");
        }

    }
}
