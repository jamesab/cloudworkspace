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


namespace cludworkspace.Controllers
{
    //[Authorize]
    public class ClientsController : Controller
    {
        //private ApplicationDbContext dbContext = new ApplicationDbContext();
        private DALDbContext dbContext = new DALDbContext();
        ClientRepository iClient;
        // GET: Clients
        public ActionResult Index()
        {
            iClient = new ClientRepository(dbContext);
            
            return View(iClient.GetClientViewModelList());                      
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Client client = dbContext.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CloudWorkSpace.DAL.ViewModels.ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientTb = new Client();
                    clientTb.Name = client.Name;
                    clientTb.Email = client.Email;
                    clientTb.IsACompany = client.IsACompany;
                    clientTb.IsArchived = false;

                dbContext.Clients.Add(clientTb);
                
                Address ClientAddress = new Address();
                        ClientAddress.Name = client.AddressName;
                        ClientAddress.Street1 = client.Street1;
                        ClientAddress.Street2 = client.Street2;
                        ClientAddress.City = client.City;
                        ClientAddress.State = client.State;
                        ClientAddress.ZipCode = client.ZipCode;
                Phone ClientPhone = new Phone();
                        ClientPhone.Name = client.PhoneName;
                        ClientPhone.PhoneNumber = client.PhoneNumber;
                // Phone
                clientTb.Phone.Add(ClientPhone);
                // Address
                clientTb.Address.Add(ClientAddress);

                int clientId = dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = dbContext.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,Email,IsACompany,IsArchived")] Client client)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(client).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = dbContext.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = dbContext.Clients.Find(id);
            dbContext.Clients.Remove(client);
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
