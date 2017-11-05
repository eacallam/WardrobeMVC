using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC.Models;

namespace WardrobeMVC.Controllers
{
    public class FootgearsController : Controller
    {
        private WardrobeMVCContext db = new WardrobeMVCContext();

        // GET: Footgears
        public ActionResult Index()
        {
            var footgears = db.Footgears.Include(f => f.Color).Include(f => f.Occasion).Include(f => f.Season);
            return View(footgears.ToList());
        }

        // GET: Footgears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footgear footgear = db.Footgears.Find(id);
            if (footgear == null)
            {
                return HttpNotFound();
            }
            return View(footgear);
        }

        // GET: Footgears/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1");
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1");
            return View();
        }

        // POST: Footgears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FootgearID,Name,Photo,Type,ColorID,SeasonID,OccasionID")] Footgear footgear)
        {
            if (ModelState.IsValid)
            {
                db.Footgears.Add(footgear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1", footgear.ColorID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", footgear.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", footgear.SeasonID);
            return View(footgear);
        }

        // GET: Footgears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footgear footgear = db.Footgears.Find(id);
            if (footgear == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1", footgear.ColorID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", footgear.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", footgear.SeasonID);
            return View(footgear);
        }

        // POST: Footgears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FootgearID,Name,Photo,Type,ColorID,SeasonID,OccasionID")] Footgear footgear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footgear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "Color1", footgear.ColorID);
            ViewBag.OccasionID = new SelectList(db.Occasions, "OccasionID", "Occasion1", footgear.OccasionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", footgear.SeasonID);
            return View(footgear);
        }

        // GET: Footgears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footgear footgear = db.Footgears.Find(id);
            if (footgear == null)
            {
                return HttpNotFound();
            }
            return View(footgear);
        }

        // POST: Footgears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Footgear footgear = db.Footgears.Find(id);
            db.Footgears.Remove(footgear);
            db.SaveChanges();
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
