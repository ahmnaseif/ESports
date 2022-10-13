using ESports.Models;
using ESports.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESports.Controllers
{
    public class PlayerRegisterController : Controller
    {
        private DBESportsEntities1 objDBESportsEntities1;
        private DBESportsEntities1 db = new DBESportsEntities1();

        public PlayerRegisterController()
        {
            objDBESportsEntities1 = new DBESportsEntities1();
        }

        public ActionResult Index()
        {
            Teams objTeam = new Teams();
            objTeam.TrSelectListItem = (from objCat in objDBESportsEntities1.TournamentDetails
                                        select new SelectListItem()
                                        {
                                            Text = objCat.TrName,
                                            Value = objCat.TrId.ToString(),
                                            Selected = true
                                        });
            return View(objTeam);
        }
        // GET: PlayerRegister
        public ActionResult Create()
        {
            return View();
        }
    }
}