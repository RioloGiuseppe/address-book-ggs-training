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
    public class TelephoneNumbersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TelephoneNumbers
        public async Task<ActionResult> Index()
        {
            var telephoneNumbers = db.TelephoneNumbers.Include(t => t.Contact);
            return View(await telephoneNumbers.ToListAsync());
        }

        // GET: TelephoneNumbers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber = await db.TelephoneNumbers.FindAsync(id);
            if (telephoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name");
            return View();
        }

        // POST: TelephoneNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ContactId,Number,Type")] TelephoneNumber telephoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.TelephoneNumbers.Add(telephoneNumber);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", telephoneNumber.ContactId);
            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber = await db.TelephoneNumbers.FindAsync(id);
            if (telephoneNumber == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", telephoneNumber.ContactId);
            return View(telephoneNumber);
        }

        // POST: TelephoneNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ContactId,Number,Type")] TelephoneNumber telephoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telephoneNumber).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name", telephoneNumber.ContactId);
            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber = await db.TelephoneNumbers.FindAsync(id);
            if (telephoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(telephoneNumber);
        }

        // POST: TelephoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TelephoneNumber telephoneNumber = await db.TelephoneNumbers.FindAsync(id);
            db.TelephoneNumbers.Remove(telephoneNumber);
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
