//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESports.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class PlayerReg
    {
        public string Username { get; set; }
        public int TournamentId { get; set; }
        public int PlayerRegId { get; set; }

        public IEnumerable<SelectListItem> TrSelectListItem { get; set; }
    }
}
