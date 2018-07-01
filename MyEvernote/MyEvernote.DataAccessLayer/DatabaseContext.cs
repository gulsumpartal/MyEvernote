using MyEvernote.Entities;
using System.Configuration;
using System.Data.Entity;

namespace MyEvernote.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        #region Constructor
        public DatabaseContext():base(ConfigurationManager.ConnectionStrings["DatabaseContext"].Name)
        {
            //bu kısım packege manager kullanmazsan aç ve test view çağr
            //Database.SetInitializer(new MyInitializer());
            //MyInıtializer clası seed methodunu içeren bir class tır 
        } 
        #endregion
        #region Entities
        public DbSet<EvernoteUser> EvernoteUsers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likes { get; set; }
        #endregion
    }
}
