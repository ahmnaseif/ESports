using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESports.Models;
using ESports.ViewModel;

namespace ESports.Controllers
{
    public class CasController : Controller
    {
        private DBESportsEntities1 db = new DBESportsEntities1();
        // GET: Cas
        public ActionResult Index()
        {
            ViewBag.TournamentList = new SelectList(GetTournamentList(), "TrId", "TrName");
            return View();
        }

        public List<TournamentDetail> GetTournamentList()
        {
            
            List<TournamentDetail> Tournaments = db.TournamentDetails.ToList();
            return Tournaments;
        }

        public ActionResult GetPlayerList(int TrId)
        {
            List<PlayerReg> selectList = db.PlayerRegs.Where(x => x.TournamentId == TrId).ToList();
            ViewBag.SList = new SelectList(selectList, "Username", "Username");
            return PartialView("DisplayPlayers");
        }

        public ActionResult GetTeamList(int TrId)
        {
            List<Team> selectList = db.Teams.Where(x => x.TournamentId == TrId).ToList();
            ViewBag.TeamList = new SelectList(selectList, "TeamId", "TeamName");
            return PartialView("DisplayTeams");
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidId,TournamentId,TeamId,Username,Amount,Other")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auction);
        }
    }
}