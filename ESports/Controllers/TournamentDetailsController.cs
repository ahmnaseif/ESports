using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESports.Models;

namespace ESports.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TournamentDetailsController : Controller
    {
        private DBESportsEntities1 db = new DBESportsEntities1();

        // GET: TournamentDetails
        public ActionResult Index()
        {
            return View(db.TournamentDetails.ToList());
        }

        // GET: TournamentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
            if (tournamentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetail);
        }

        // GET: TournamentDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournamentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrId,TrName")] TournamentDetail tournamentDetail)
        {
            if (ModelState.IsValid)
            {
                db.TournamentDetails.Add(tournamentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tournamentDetail);
        }

        // GET: TournamentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
            if (tournamentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetail);
        }

        // POST: TournamentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrId,TrName,TrDetails")] TournamentDetail tournamentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournamentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tournamentDetail);
        }

        // GET: TournamentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
            if (tournamentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tournamentDetail);
        }

        // POST: TournamentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TournamentDetail tournamentDetail = db.TournamentDetails.Find(id);
            db.TournamentDetails.Remove(tournamentDetail);
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
