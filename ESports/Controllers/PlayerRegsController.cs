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
    public class PlayerRegsController : Controller
    {
        private DBESportsEntities1 objDBESportsEntities1;
        private DBESportsEntities1 db = new DBESportsEntities1();

        public PlayerRegsController()
        {
            objDBESportsEntities1 = new DBESportsEntities1();
        }
        public ActionResult Create()
        {
            PlayerReg objPlayerReg = new PlayerReg();
            objPlayerReg.TrSelectListItem = (from objCat in objDBESportsEntities1.TournamentDetails
                                        select new SelectListItem()
                                        {
                                            Text = objCat.TrName,
                                            Value = objCat.TrId.ToString(),
                                            Selected = true
                                        });
            return View(objPlayerReg);
        }

        // GET: PlayerRegs
        public ActionResult Index()
        {
            return View(db.PlayerRegs.ToList());
        }

        // GET: PlayerRegs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerReg playerReg = db.PlayerRegs.Find(id);
            if (playerReg == null)
            {
                return HttpNotFound();
            }
            return View(playerReg);
        }

        // GET: PlayerRegs/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: PlayerRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,TournamentId,PlayerRegId")] PlayerReg playerReg)
        {
            if (ModelState.IsValid)
            {
                db.PlayerRegs.Add(playerReg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerReg);
        }

        // GET: PlayerRegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerReg playerReg = db.PlayerRegs.Find(id);
            if (playerReg == null)
            {
                return HttpNotFound();
            }
            return View(playerReg);
        }

        // POST: PlayerRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,TournamentId,PlayerRegId")] PlayerReg playerReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerReg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerReg);
        }

        // GET: PlayerRegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerReg playerReg = db.PlayerRegs.Find(id);
            if (playerReg == null)
            {
                return HttpNotFound();
            }
            return View(playerReg);
        }

        // POST: PlayerRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerReg playerReg = db.PlayerRegs.Find(id);
            db.PlayerRegs.Remove(playerReg);
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
