using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly Lazy<INoteService> _noteService;

        public NoteController()
        {
            _noteService = new Lazy<INoteService>(() => //empty set yields new NoteService : anonymous function syntax
                new NoteService(Guid.Parse(User.Identity.GetUserId())));
        }

        public NoteController(Lazy<INoteService> noteService) 
        {
            _noteService = noteService;
        }


        // GET: Notes
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new NoteService(userId);
            var model = _noteService.Value.GetNotes(); //service.GetNotes(); 'Value' refers back to Lazy pattern: declarative code 
            return View(model);
        }

        public ActionResult Create(Lazy<INoteService> model)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var service = CreateNoteService();

            if (_noteService.Value.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created");
            return View(model);
        }

       

        public ActionResult Details(int id)
        {
            //var svc = CreateNoteService();
            var model = _noteService.Value.GetNoteById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            //var service = CreateNoteSevice();
            var detail = _noteService.Value.GetNoteById(id);
            var model =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NoteEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            //var service = CreateNoteService();

            if (_noteService.Value.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your note was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            //var svc = CreateNoteService();
            var model = _noteService.Value.GetNoteById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
          
            //var service = CreateNoteService();
            _noteService.Value.DeleteNote(id);

            TempData["SaveResult"] = "Your note was deleted";


            return RedirectToAction("Index");
        }
    }
}