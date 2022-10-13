using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESports.Models
{
    public class TournamentsWithPlayers
    {
        //public TournamentsWithPlayers()
        //{
        //    this.Tournaments = new List<SelectListItem>();
        //    this.Players = new List<SelectListItem>();
        //}

        //public List<SelectListItem> Tournaments { get; set; }
        //public List<SelectListItem> Players { get; set; }

        public int BidId { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public string Username { get; set; }


        public decimal Amount { get; set; }

        public string Other { get; set; }
    }
}