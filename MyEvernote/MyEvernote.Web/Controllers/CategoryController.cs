using MyEvernote.BusinessLayer.Categories;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetNotesByCategoryId(int? categoryId)
        {
            Category model = new CategoryService().GetCategoryById(categoryId.Value);

            return PartialView("~/Views/Note/_NoteListPartial.cshtml", model.Notes);
        }

    }
}