using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HMSWebApp.Enums;
using HMSWebApp.Interfaces;

namespace HMSWebApp.Models
{
    public class VoteEntry : IObjectWithState
    {
        public VoteEntry()
        {
        }

        public VoteEntry(int voteEntryId)
        {
            Id = voteEntryId;
        }

        public int Id { get; private set; }
        public string Type { get; set; }
        public int VoterId { get; set; }
        public int TeamId { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        [NotMapped]
        public State State { get; set; }
}
}