namespace MyEvernote.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbAddingIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Notes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.EvernoteUsers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EvernoteUsers", "IsDeleted");
            DropColumn("dbo.Comments", "IsDeleted");
            DropColumn("dbo.Notes", "IsDeleted");
            DropColumn("dbo.Categories", "IsDeleted");
        }
    }
}
