using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESports.Models;
using ESports.ViewModel;

namespace ESports.Controllers
{
    public class PlayerController : Controller
    {
        private DBESportsEntities1 objDBESportsEntities1; 
        public PlayerController()
        {
            objDBESportsEntities1 = new DBESportsEntities1();
        }
        // GET: Player
        public ActionResult Index()
        {
            //PlayerViewModel objPlayerViewModel = new PlayerViewModel();
            
            return View();
        }
    }
}