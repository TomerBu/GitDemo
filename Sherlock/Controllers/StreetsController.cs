using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sherlock.DAL;
using Sherlock.Models;

namespace Sherlock.Controllers
{
    public class StreetsController : Controller
    {
        private SherlockContext db = new SherlockContext();

        // GET: Streets
        public async Task<ActionResult> Index()
        {
            var streets = db.Streets.Include(s => s.City);
            return View(await streets.ToListAsync());
        }

        // GET: Streets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = await db.Streets.FindAsync(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StreetID,Name,EnglishName,CityID")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Streets.Add(street);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", street.CityID);
            return View(street);
        }

        // GET: Streets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = await db.Streets.FindAsync(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", street.CityID);
            return View(street);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StreetID,Name,EnglishName,CityID")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Entry(street).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", street.CityID);
            return View(street);
        }

        // GET: Streets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = await db.Streets.FindAsync(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Street street = await db.Streets.FindAsync(id);
            db.Streets.Remove(street);
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
