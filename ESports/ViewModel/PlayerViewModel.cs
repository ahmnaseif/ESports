using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESports.ViewModel
{
    public class PlayerViewModel
    {
        public string Username { get; set; }
        public string Batting { get; set; }
        public string Bowling { get; set; }
        public string Other { get; set; }
        public HttpPostedFileBase Photo { get; set; }
    }
}