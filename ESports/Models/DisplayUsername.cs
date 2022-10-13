using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESports.Models
{
    public class DisplayUsername
    {
        public static string passUsername;

        public static void getUsername(string Username)
        {
            passUsername = Username;
        }
    }
}