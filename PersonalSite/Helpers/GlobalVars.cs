using PersonalSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalSite.Helpers
{
    public static class GlobalVars
    {

        public static SelectList LanguageChoices
        {
            get
            {
                return new SelectList(
                    new List<SelectListItem>
                    {
                        new SelectListItem { Text = "Please Choose a language", Value = "Please Choose a Language" },
                        new SelectListItem { Text = "C#", Value = ((int)Language.CSharp).ToString() },
                        new SelectListItem { Text = "ObjC", Value = ((int)Language.ObjC).ToString() },
                        new SelectListItem { Text = "Swift", Value = ((int)Language.Swift).ToString() }
                    }, "Value", "Text"
                );
            }
            
        }

        
    }
}