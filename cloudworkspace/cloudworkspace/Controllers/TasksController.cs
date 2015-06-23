
using CloudWorkSpace.DAL.Repositories;
using CloudWorkSpace.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;


namespace DataAccessLayer.Controllers
{
    //[Authorize]
    public class TasksController : Controller
    {
        private DALDbContext dbContext = new DALDbContext();
        TaskRepository iTask;

        // GET: Tasks
        public ActionResult Index()
        {
            iTask = new TaskRepository(dbContext);
            return View(iTask.Get().ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloudWorkSpace.DAL.DTO.ProjectTask task = iTask.GetByID(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,ProjectName,TaskName,IsBug,TotalTimeSpent,CompletionDate,StartDate,Current_Status,IsArchived")] CloudWorkSpace.DAL.DTO.ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                dbContext.Tasks.Add(task);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloudWorkSpace.DAL.DTO.ProjectTask task = iTask.GetByID(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,ProjectName,TaskName,IsBug,TotalTimeSpent,CompletionDate,StartDate,Current_Status,IsArchived")] CloudWorkSpace.DAL.DTO.ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(task).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloudWorkSpace.DAL.DTO.ProjectTask task = iTask.GetByID(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTask task = dbContext.Tasks.Find(id);
            dbContext.Tasks.Remove(task);
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
