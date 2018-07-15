using MyEvernote.BusinessLayer.Notes;
using MyEvernote.Common.Service;
using MyEvernote.DTO.Notes;
using MyEvernote.DTO.Users;
using MyEvernote.Web.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteService _noteService;
        public HomeController()
        {
            _noteService = new NoteService();
        }
        // GET: Home
        public ActionResult Index()
        {
            //var model = new NoteService().GetNotes();
            var model = _noteService.GetNotesOrderByDescByModifiedOn();
            return View(model);
        }

        public ActionResult NotesByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<NoteListDto> notes = _noteService.GetNotesByCategoryId(id.Value);
            if (notes == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", notes);
        }

        public ActionResult MostLiked()
        {
            var model = _noteService.GetNotesOrderByDescByLikeCount();

            return View("Index", model);
        }

        public ActionResult About()
        {
            return View();
        }

    }
}