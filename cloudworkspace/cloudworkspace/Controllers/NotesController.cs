using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using CloudWorkSpace.DAL.Repositories;
using CloudWorkSpace.DAL.DTO;

namespace DataAccessLayer.Controllers
{
    //[Authorize]
    public class NotesController : Controller
    {
        //private ApplicationDbContext dbContext = new ApplicationDbContext();
        private DALDbContext dbContext = new DALDbContext();
        NoteRepository iNote;
        // GET: Notes
        public ActionResult Index()
        {
            var notes = dbContext.Notes.Include(n => n.Projects);
            return View(notes.ToList());
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = dbContext.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {            
            ViewBag.ProjectId = new SelectList(dbContext.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoteId,Note_Comment,Topic,ProjectId")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.CreatedDate = DateTime.Now;
                note.UserName = User.Identity.Name;
                dbContext.Notes.Add(note);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.ProjectId = new SelectList(dbContext.Projects, "ProjectId", "ProjectName", note.ProjectId);
            return View(note);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = dbContext.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.ProjectId = new SelectList(dbContext.Projects, "ProjectId", "ProjectName", note.ProjectId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoteId,Note_Comment,Topic,CreatedDate,IsArchived,AspNetUserId,ProjectId")] Note note)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(note).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.ProjectId = new SelectList(dbContext.Projects, "ProjectId", "ProjectName", note.ProjectId);
            return View(note);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = dbContext.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = dbContext.Notes.Find(id);
            dbContext.Notes.Remove(note);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
