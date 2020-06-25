using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using address_book_ggs_training.Entities;
using address_book_ggs_training.Models;
using address_book_ggs_training.Extension;

namespace address_book_ggs_training.Controllers
{
    public class EmailAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmailAddresses
        public async Task<ActionResult> Index()
        {
            var emailAddresses = db.EmailAddresses.Include(e => e.Contact);
            return View(await emailAddresses.ToListAsync());
        }

        // GET: EmailAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailAddress emailAddress = await db.EmailAddresses.FindAsync(id);
            if (emailAddress == null)
            {
                return HttpNotFound();
            }
            return View(emailAddress);
        }

        // GET: EmailAddresses/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name");
            return View();
        }

        // POST: EmailAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,Type,ContactId")] EmailAddress emailAddress)
        {
            if (ModelState.IsValid)
            {
                db.EmailAddresses.Add(emailAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", emailAddress.ContactId);
            return View(emailAddress);
        }

        // GET: EmailAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailAddress emailAddress = await db.EmailAddresses.FindAsync(id);
            if (emailAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", emailAddress.ContactId);
            return View(emailAddress);
        }

        // POST: EmailAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,Type,ContactId")] EmailAddress emailAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", emailAddress.ContactId);
            return View(emailAddress);
        }

        // GET: EmailAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailAddress emailAddress = await db.EmailAddresses.FindAsync(id);
            if (emailAddress == null)
            {
                return HttpNotFound();
            }
            return View(emailAddress);
        }

        // POST: EmailAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmailAddress emailAddress = await db.EmailAddresses.FindAsync(id);
            db.EmailAddresses.Remove(emailAddress);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
