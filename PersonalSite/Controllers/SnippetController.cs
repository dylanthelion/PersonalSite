using PersonalSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            ViewBag.Title = "Snippets";
            ViewBag.Header = "_secondaryHeader";
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
            ViewBag.HeaderTitle = "Create a Snippet";
            ViewBag.Title = "Post a Snippet";
            ViewBag.Header = "_secondaryHeader";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string language, Snippet snippet)
        {
            ViewBag.HeaderTitle = "Create a Snippet";
            ViewBag.Title = "Post a Snippet";
            ViewBag.Header = "_secondaryHeader";
            if (!ModelState.IsValid)
            {
                return View(snippet);
            }

            db.AllSnippets.Add(snippet);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPatch]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Snippet snippet)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = snippet.ID });
            }

            var oldSnippet = db.AllSnippets.Find(snippet.ID);
            oldSnippet = snippet;
            db.Entry(oldSnippet).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ViewSnippet", new { id = snippet.ID });
        }

    }
}
