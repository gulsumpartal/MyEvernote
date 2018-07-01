namespace MyEvernote.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUserName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        EvernoteUserId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 60),
                        Text = c.String(nullable: false, maxLength: 2000),
                        IsDraft = c.Boolean(nullable: false),
                        LikeCount = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUserName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.EvernoteUsers", t => t.EvernoteUserId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.EvernoteUserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteId = c.Int(nullable: false),
                        EvernoteUserId = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUserName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notes", t => t.NoteId, cascadeDelete: false)
                .ForeignKey("dbo.EvernoteUsers", t => t.EvernoteUserId, cascadeDelete: false)
                .Index(t => t.NoteId)
                .Index(t => t.EvernoteUserId);
            
            CreateTable(
                "dbo.EvernoteUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        Username = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 70),
                        Password = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        ActivateGuid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUserName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteId = c.Int(nullable: false),
                        EvernoteUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvernoteUsers", t => t.EvernoteUserId, cascadeDelete: false)
                .ForeignKey("dbo.Notes", t => t.NoteId, cascadeDelete: false)
                .Index(t => t.NoteId)
                .Index(t => t.EvernoteUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "EvernoteUserId", "dbo.EvernoteUsers");
            DropForeignKey("dbo.Likes", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Likes", "EvernoteUserId", "dbo.EvernoteUsers");
            DropForeignKey("dbo.Comments", "EvernoteUserId", "dbo.EvernoteUsers");
            DropForeignKey("dbo.Comments", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Notes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Likes", new[] { "EvernoteUserId" });
            DropIndex("dbo.Likes", new[] { "NoteId" });
            DropIndex("dbo.Comments", new[] { "EvernoteUserId" });
            DropIndex("dbo.Comments", new[] { "NoteId" });
            DropIndex("dbo.Notes", new[] { "EvernoteUserId" });
            DropIndex("dbo.Notes", new[] { "CategoryId" });
            DropTable("dbo.Likes");
            DropTable("dbo.EvernoteUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Notes");
            DropTable("dbo.Categories");
        }
    }
}
