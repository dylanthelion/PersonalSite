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
            ViewBag.HeaderTitle = "Snippet";
            ViewBag.Title = "Snippet";
            ViewBag.Header = "_secondaryHeader";
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
        public ActionResult Create(Snippet snippet)
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
            ViewBag.HeaderTitle = "Edit your Snippet";
            ViewBag.Title = "Edit Snippet";
            ViewBag.Header = "_secondaryHeader";
            Snippet snippet = db.AllSnippets.Find(id);

            ViewBag.LanguageValue = (int)snippet.Language;

            switch (snippet.Language)
            {
                case Language.CSharp:
                    {
                        ViewBag.Language = "C#";
                        return View(snippet);
                    }

                case Language.ObjC:
                    {
                        ViewBag.Language = "Objective C";
                        return View(snippet);
                    }

                case Language.Swift:
                    {
                        ViewBag.Language = "Swift";
                        return View(snippet);
                    }

                default:
                    {
                        ViewBag.Language = "Error";
                        return View(snippet);
                    }
            }

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Snippet snippet)
        {
            ViewBag.HeaderTitle = "Edit your Snippet";
            ViewBag.Title = "Edit Snippet";
            ViewBag.Header = "_secondaryHeader";
            if (!ModelState.IsValid)
            {
                return View(snippet);
            }

            db.Entry(snippet).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ViewSnippet", new { id = snippet.ID });
        }

        public ActionResult Delete(int id)
        {
            ViewBag.HeaderTitle = "Edit your Snippet";
            ViewBag.Title = "Edit Snippet";
            ViewBag.Header = "_secondaryHeader";
            Snippet snippet = db.AllSnippets.Find(id);

            ViewBag.LanguageValue = (int)snippet.Language;

            switch (snippet.Language)
            {
                case Language.CSharp:
                    {
                        ViewBag.Language = "C#";
                        return View(snippet);
                    }

                case Language.ObjC:
                    {
                        ViewBag.Language = "Objective C";
                        return View(snippet);
                    }

                case Language.Swift:
                    {
                        ViewBag.Language = "Swift";
                        return View(snippet);
                    }

                default:
                    {
                        ViewBag.Language = "Error";
                        return View(snippet);
                    }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Snippet snippet, string password)
        {
            ViewBag.HeaderTitle = "Edit your Snippet";
            ViewBag.Title = "Edit Snippet";
            ViewBag.Header = "_secondaryHeader";
            if(snippet != null && password.Equals("DeleteMe"))
            {
                Snippet snippetToDelete = db.AllSnippets.Find(snippet.ID);
                db.AllSnippets.Remove(snippetToDelete);
                db.Entry(snippetToDelete).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageValue = (int)snippet.Language;

            switch (snippet.Language)
            {
                case Language.CSharp:
                    {
                        ViewBag.Language = "C#";
                        return View(snippet);
                    }

                case Language.ObjC:
                    {
                        ViewBag.Language = "Objective C";
                        return View(snippet);
                    }

                case Language.Swift:
                    {
                        ViewBag.Language = "Swift";
                        return View(snippet);
                    }

                default:
                    {
                        ViewBag.Language = "Error";
                        return View(snippet);
                    }
            }
        }

    }
}
