using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebApp.ViewModels
{
    public class VoteEntryViewModel
    {
        public int VoteEntryId { get; set; }
        public string VoterLastName { get; set; }
        public string VoterFirstName { get; set; }
        public string VoterEmailAddress { get; set; }
        public string VoteEntryType { get; set; }
        public int TeamId { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public double PaymentPesoEquivalent { get; set; }
    }
}