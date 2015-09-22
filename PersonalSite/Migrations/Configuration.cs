namespace PersonalSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PersonalSite.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalSite.Models.SnippetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(PersonalSite.Models.SnippetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var s1 = new Snippet { Code = "Test", Description = "Test", ID = 1, Language = Language.CSharp, Title = "Test" };
            var s2 = new Snippet { Code = "Test", Description = "Test", ID = 2, Language = Language.ObjC, Title = "Test" };
            var s3 = new Snippet { Code = "Test", Description = "Test", ID = 3, Language = Language.Swift, Title = "Test" };

            context.AllSnippets.AddOrUpdate(
                s => s.ID,
                s1,
                s2,
                s3
                );
        }
    }
}
