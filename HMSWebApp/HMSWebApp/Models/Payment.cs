using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HMSWebApp.Enums;
using HMSWebApp.Interfaces;

namespace HMSWebApp.Models
{
    public class Payment : IObjectWithState
    {
        public Payment()
        {

        }

        public Payment(double amount, string currency, double pesoEquivalent)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.PesoEquivalent = pesoEquivalent;
        }

        public int Id { get; private set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public double PesoEquivalent { get; set; }

        [NotMapped]
        public State State { get; set; }
    }
}