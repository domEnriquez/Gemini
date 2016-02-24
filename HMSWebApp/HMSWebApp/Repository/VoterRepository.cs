using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class VoterRepository
    {
        HMSDb _db = new HMSDb();

        public Voter Retrieve(int voterId)
        {
            var voter = _db.Voter.Find(voterId);
            return voter;
        }

        public Voter RetrieveByName(string LastName, string FirstName)
        {
            Voter voter = _db.Voter.Where(v => v.LastName == LastName && v.FirstName == FirstName).FirstOrDefault();
            return voter;
        }

        public Voter RetrieveByEmailAddress(string emailAddress)
        {
            Voter voter = _db.Voter.Where(v => v.EmailAddress == emailAddress).FirstOrDefault();
            return voter;
        }

        public void StoreVoter(Voter voter)
        {
            if (voter != null)
            {
                _db.Voter.Add(voter);
                _db.SaveChanges();
            }

        }

        public void AddVoterIfNonExisting(Voter voter)
        {
            if (RetrieveByEmailAddress(voter.EmailAddress) == null)
            {
                StoreVoter(voter);
            }
        }
    }
}