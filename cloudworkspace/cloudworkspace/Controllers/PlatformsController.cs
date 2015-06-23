
using CloudWorkSpace.DAL.DTO;
using CloudWorkSpace.DAL.Repositories;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace cloudworkspace.Controllers
{
    //[Authorize]
    public class PlatformsController : Controller
    {
        private DALDbContext dbContext = new DALDbContext();
        PlatformRepository iPlatform;

        // GET: Platforms
        public ActionResult Index()
        {
            return View(dbContext.Platforms.ToList());
        }

        // GET: Platforms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = dbContext.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // GET: Platforms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Platforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                dbContext.Platforms.Add(platform);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(platform);
        }

        // GET: Platforms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = dbContext.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // POST: Platforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(platform).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platform);
        }

        // GET: Platforms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = dbContext.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // POST: Platforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Platform platform = dbContext.Platforms.Find(id);
            dbContext.Platforms.Remove(platform);
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
