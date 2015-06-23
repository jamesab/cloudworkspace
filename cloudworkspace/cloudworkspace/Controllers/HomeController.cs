
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DAL;
using CloudWorkSpace.DAL.DTO;

namespace cloudworkspace.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private DALDbContext dbContext = new DALDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Time()
        {            
            return View();
        }

        public ActionResult Clients()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        #region Partials

        public PartialViewResult PaginationPartial(int? page = null)
        {
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            List<Project> Projects;
            
            if (dbContext.Projects.ToList().Count() > 10)
            {
                Projects = dbContext.Projects.Skip(pageNumber).Take(10).ToList();
            }
            else
            {
                 Projects = dbContext.Projects.ToList();
            }


            ViewBag.Page = Projects;

            return PartialView("_PaginationPartial", Projects);
        }

        public PartialViewResult ProjectPartial()
        {
            return PartialView("_ProjectPanelPartial", dbContext.Projects.ToList());
        }

        public PartialViewResult TasksPanelPartial()
        {
            return PartialView("_TasksPanelPartial", dbContext.Tasks.ToList());
        }

        public PartialViewResult InvoicePanelPartial()
        {
            return PartialView("_InvoicePanelPartial", dbContext.Invoices.ToList());
        }

        public PartialViewResult CommentAndNotesPartial()
        {
            return PartialView("_CommentAndNotesPartial", dbContext.Notes.ToList());
        }

        #endregion

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