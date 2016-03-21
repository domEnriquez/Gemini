using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebApp.Models
{
    public class VoteEntry
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
    }
}