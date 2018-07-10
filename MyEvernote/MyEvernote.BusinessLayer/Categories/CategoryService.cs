using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.DTO.Categories;
using MyEvernote.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyEvernote.BusinessLayer.Categories
{
    public class CategoryService
    {
        private readonly Repository<Category> repo;
        public CategoryService()
        {
            repo = new Repository<Category>();
        }
        public List<CategoryListDto> GetCategories()
        {
            return repo.ListQueryableWithWhere(p => p.IsDeleted == false).Select(p => new CategoryListDto
            {
                CategoryId = p.Id,
                Description = p.Description,
                Title = p.Title
            }).ToList();
        }
        //public CategoriesDetail GetCategoryById(int id)
        //{
        //    var data = repo.ListQueryableWithWhere(p => p.IsDeleted == false && p.Id == id).Select(p => new CategoriesDetail
        //    {
        //        CategoryId=p.Id,
        //        Description=p.Description,
        //        Title=p.Title,
        //        Notes=p.Notes
        //    }
        //    );
        //}

    }
}
