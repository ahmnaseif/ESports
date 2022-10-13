using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ESports.Models;

namespace ESports.Controllers
{
    public class BidsController : Controller
    {
        private DBESportsEntities1 db = new DBESportsEntities1();
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBESportsEntities1"].ConnectionString);
        // GET: Bids
        public ActionResult Index()
        {
            //Cascading_ddlEntities entities = new Cascading_ddlEntities();
            TournamentsWithPlayers model = new TournamentsWithPlayers();
            //foreach (var tournament in db.TournamentDetails)
            //{
            //    model.Tournaments.Add(new SelectListItem { Text = tournament.TrName, Value = tournament.TrId.ToString() });
            //}
            //return View(model);
            return View(db.PlayerRegs.ToList());
        }


        //[HttpPost]
        //public ActionResult Index(int? tournamentId, int? playerID)
        //{
        //    TournamentsWithPlayers model = new TournamentsWithPlayers();
        //    //Cascading_ddlEntities entities = new Cascading_ddlEntities();
        //    //foreach (var tournament in db.TournamentDetails)
        //    //{
        //    //    model.Tournaments.Add(new SelectListItem { Text = tournament.TrName, Value = tournament.TrId.ToString() });
        //    //}

        //    //if (tournamentId.HasValue)
        //    //{
        //    //    var players = (from player in db.PlayerRegs
        //    //                  where player.TournamentId == tournamentId.Value
        //    //                  select player).ToList();
        //    //    foreach (var player in players)
        //    //    {
        //    //        model.Players.Add(new SelectListItem { Text = player.Username, Value = player.Username.ToString() });
        //    //    }

               
        //    //}

        //    //return View(model);
        //}

        // GET: Bids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            return View();
        }

        

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BId1,Username,TeamId,Amount")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bid);
        }

        // GET: Bids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BId1,Username,TeamId,Amount")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bid);
        }

        // GET: Bids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bid bid = db.Bids.Find(id);
            db.Bids.Remove(bid);
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
