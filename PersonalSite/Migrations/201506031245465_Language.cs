namespace PersonalSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Language : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Snippets", "Language", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Snippets", "Language");
        }
    }
}
