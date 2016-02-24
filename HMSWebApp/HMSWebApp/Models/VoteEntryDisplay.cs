using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSWebApp.Models
{
    public class VoteEntryDisplay
    {
        public VoteEntryDisplay()
        {
            Payment = new Payment();
            Voter = new Voter();
        }

        public Voter Voter {get; set; }
        public string TeamName { get; set; } //Team name voted
        public string VoteEntryType { get; set; }
        public Payment Payment { get; set; }
    }
}