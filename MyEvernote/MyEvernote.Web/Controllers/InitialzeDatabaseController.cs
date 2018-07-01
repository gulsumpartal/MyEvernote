using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class InitialzeDatabaseController : Controller
    {
        // GET: InitialzeDatabase
        public ActionResult Index()
        {
            BusinessLayer.Test test = new BusinessLayer.Test();
            //test.InsertTest();
            test.CommentTest();
            return View();
        }
    }
}