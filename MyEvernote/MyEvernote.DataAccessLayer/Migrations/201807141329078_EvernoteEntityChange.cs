namespace MyEvernote.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvernoteEntityChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EvernoteUsers", "ImageFilePath", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EvernoteUsers", "ImageFilePath");
        }
    }
}
