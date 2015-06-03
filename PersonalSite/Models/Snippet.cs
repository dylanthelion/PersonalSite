using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonalSite.Models
{
    public class Snippet
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public Language Language { get; set; }
    }

    public class SnippetContext : DbContext
    {
        public SnippetContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Snippet> AllSnippets { get; set; }
    }

    public enum Language
    {
        CSharp,
        ObjC,
        Swift
    };
}