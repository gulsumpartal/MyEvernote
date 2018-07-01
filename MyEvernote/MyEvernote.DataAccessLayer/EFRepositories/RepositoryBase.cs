namespace MyEvernote.DataAccessLayer.EFRepositories
{
    public class RepositoryBase
    {
        protected  static DatabaseContext db;
        private static object _lockSync = new object();
        protected RepositoryBase() //sadece miras alan yerlerde newlenmesi sağlanır
        {
           CreateContext();
        }
        private static void CreateContext()
        {
            if (db == null)
            {
                lock (_lockSync)
                {
                    if (db == null)
                    {
                        db = new DatabaseContext();
                    }
                }
            }
        }
    }
}
