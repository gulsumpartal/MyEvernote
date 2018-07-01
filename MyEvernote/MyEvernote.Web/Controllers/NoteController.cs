using MyEvernote.BusinessLayer.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult FillNotesPartial()
        {
            var model = new NoteService().GetNotes();
            return PartialView("~/Views/Note/_NoteListPartial.cshtml", model);
        }
    }
}