using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESports.ViewModel
{
    public class Teams
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ManagerName { get; set; }
        public int TournamentId { get; set; }
        public string Details { get; set; }

        public IEnumerable<SelectListItem> TrSelectListItem { get; set; }
    }
}