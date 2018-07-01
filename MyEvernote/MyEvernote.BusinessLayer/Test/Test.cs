using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.Entities;
using System;

namespace MyEvernote.BusinessLayer
{
    public class Test
    {
        Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        Repository<Comment> repo_comment = new Repository<Comment>();
        Repository<Note> repo_note = new Repository<Note>();
        public Test()
        {
            DataAccessLayer.DatabaseContext dbObject = new DataAccessLayer.DatabaseContext();
            dbObject.Database.CreateIfNotExists();
            //    //dbObject.Categories.ToList(); //seed methodu çalışşsın diye bunu ekleriz yukardakini kapat

            //Repository<Category> repo = new Repository<Category>();
            //var categories= repo.List();
        }
        public void InsertTest()
        {


            EvernoteUser user = new EvernoteUser
            {
                Name = "test",
                Surname = "test",
                Username = "testtest",
                Email = "testæmailinator.com",
                Password = "123456",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(20),
                ModifiedUserName = "adminadmin"
            };
            int resulr = repo_user.Insert(user);
        }
        public void CommentTest()
        {
            EvernoteUser user = repo_user.Find(p => p.Id == 5);
            Note note = repo_note.Find(p => p.Id == 4);

            Comment comment = new Comment
            {
                Text = "Bu bir testdir",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUserName = "admin",
                Note = note,
                Owner = user
            };

            var result = repo_comment.Insert(comment);
        }
    }
}
