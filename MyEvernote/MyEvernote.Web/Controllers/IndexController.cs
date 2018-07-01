using MyEvernote.BusinessLayer.Notes;
using MyEvernote.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {           
            return View();
        }
    }
}