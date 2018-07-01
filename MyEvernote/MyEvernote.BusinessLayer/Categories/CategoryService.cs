using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.Entities;
using System.Collections.Generic;

namespace MyEvernote.BusinessLayer.Categories
{
    public class CategoryService 
    {
        private readonly Repository<Category> repo;
        public CategoryService()
        {
            repo = new Repository<Category>();
        }
        public List<Category> GetCategories()
        {
            return repo.List();
        }
        public Category GetCategoryById(int id)
        {
            return repo.Find(p => p.Id == id);
        }
    }
}
