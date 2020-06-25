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
    public class ContainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Containers
        public async Task<ActionResult> Index()
        {
            return View(await db.Containers.ToListAsync());
        }

        // GET: Containers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = await db.Containers.FindAsync(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // GET: Containers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Containers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Container container)
        {
            if (ModelState.IsValid)
            {
                db.Containers.Add(container);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(container);
        }

        // GET: Containers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = await db.Containers.FindAsync(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: Containers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Container container)
        {
            if (ModelState.IsValid)
            {
                db.Entry(container).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(container);
        }

        // GET: Containers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Container container = await db.Containers.FindAsync(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: Containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Container container = await db.Containers.FindAsync(id);
            db.Containers.Remove(container);
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
