namespace MyEvernote.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvernoteEntityChange1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EvernoteUsers", "ImageFilePath", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EvernoteUsers", "ImageFilePath", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
