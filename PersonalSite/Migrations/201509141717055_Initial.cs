namespace PersonalSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Snippets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, unicode: false),
                        Description = c.String(nullable: false, unicode: false),
                        Code = c.String(nullable: false, unicode: false),
                        Language = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Snippets");
        }
    }
}
