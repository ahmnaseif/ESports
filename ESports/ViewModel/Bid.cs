using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESports.Models
{
    public class Bids
    {
        public int BId { get; set; }
        public string Username { get; set; }
        public int TeamId { get; set; }
        public decimal Amount { get; set; }

        public IEnumerable<SelectListItem> TeamSelectListItem { get; set; }
    }
}