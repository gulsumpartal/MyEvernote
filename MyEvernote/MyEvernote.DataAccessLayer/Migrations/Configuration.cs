namespace MyEvernote.DataAccessLayer.Migrations
{
    using MyEvernote.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyEvernote.DataAccessLayer.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyEvernote.DataAccessLayer.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            EvernoteUser adminEvernoteUser = new EvernoteUser()
            {
                Name = "admin",
                Surname = "admin",
                Email = "admin@mailinator.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "adminadmin",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedUserName = "adminadmin",
                ModifiedOn = DateTime.Now.AddMinutes(10)
            };
            EvernoteUser standartEvernoteUser = new EvernoteUser()
            {
                Name = "standart",
                Surname = "standart",
                Email = "standart@mailinator.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "standartuser",
                Password = "12345677",
                CreatedOn = DateTime.Now,
                ModifiedUserName = "adminadmin",
                ModifiedOn = DateTime.Now.AddMinutes(20)
            };
            //adding admin user
            context.EvernoteUsers.Add(adminEvernoteUser);
            //adding standart user
            context.EvernoteUsers.Add(standartEvernoteUser);

            for (int i = 0; i < 8; i++)
            {
                EvernoteUser user = new EvernoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = $"user{i}",
                    Password = "12345",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUserName = $"user{i}"
                };
                context.EvernoteUsers.Add(user);
            }

            context.SaveChanges();

            //adding fake categories
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUserName = "adminadmin"
                };

                context.Categories.Add(cat);

                List<EvernoteUser> userList = context.EvernoteUsers.ToList();
                //addinng fake notes
                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    EvernoteUser owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(20),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(3, 4)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUserName = owner.Username
                    };

                    cat.Notes.Add(note);

                    //adding fake comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        EvernoteUser comment_owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                        Comment comment = new Comment
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUserName = comment_owner.Username
                        };
                        note.Comments.Add(comment);
                    }

                    //adding fake liked
                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        Liked like = new Liked()
                        {
                            LikedUser = userList[m]
                        };
                        note.Likes.Add(like);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
