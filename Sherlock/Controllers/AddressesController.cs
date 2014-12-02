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
    public class AddressesController : Controller
    {
        private SherlockContext db = new SherlockContext();

        // GET: Addresses
        public async Task<ActionResult> Index()
        {
            var adresses = db.Adresses.Include(a => a.Apartment).Include(a => a.Street);
            return View(await adresses.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = await db.Adresses.FindAsync(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.ApartmentID = new SelectList(db.Appartments, "ApartmentID", "ApartmentID");
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "Name");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ApartmentID,BuildingNumber,AptNumber,StreetID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Adresses.Add(address);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApartmentID = new SelectList(db.Appartments, "ApartmentID", "ApartmentID", address.ApartmentID);
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "Name", address.StreetID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = await db.Adresses.FindAsync(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentID = new SelectList(db.Appartments, "ApartmentID", "ApartmentID", address.ApartmentID);
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "Name", address.StreetID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ApartmentID,BuildingNumber,AptNumber,StreetID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApartmentID = new SelectList(db.Appartments, "ApartmentID", "ApartmentID", address.ApartmentID);
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "Name", address.StreetID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = await db.Adresses.FindAsync(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Address address = await db.Adresses.FindAsync(id);
            db.Adresses.Remove(address);
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
