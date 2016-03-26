using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string TeamName { get; set; }
        public IEnumerable<SelectListItem> Teams { get; set; }
        public IEnumerable<SelectListItem> VoteEntryTypes { get; set; }
        public IEnumerable<SelectListItem> PaymentCurrencies { get; set; }
    }
}