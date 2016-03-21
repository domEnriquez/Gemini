using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class VoterRepository
    {

        #region Private Methods

        private void StoreVoter(Voter voter)
        {
            using (var _db = new HMSDb())
            {
                if (voter != null)
                {
                    _db.Voter.Add(voter);
                    _db.SaveChanges();
                }
            }
        }

        private void UpdateVoter(Voter voter)
        {
            using (var _db = new HMSDb())
            {
                if (voter != null)
                {
                    _db.Entry(voter).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }

        #endregion

        #region Public Methods

        public Voter RetrieveById(int voterId)
        {
            using (var _db = new HMSDb())
            {
                var voter = _db.Voter.Find(voterId);
                return voter;
            }
        }

        public Voter RetrieveByName(string LastName, string FirstName)
        {
            using (var _db = new HMSDb())
            {
                Voter voter = _db.Voter.Where(v => v.LastName == LastName && v.FirstName == FirstName).FirstOrDefault();
                return voter;
            }
        }

        public Voter RetrieveByEmailAddress(string emailAddress)
        {
            using (var _db = new HMSDb())
            {
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    Voter voter = _db.Voter.Where(v => v.EmailAddress == emailAddress).FirstOrDefault();
                    return voter;
                }
                return null;
            }
        }

        public bool VoterAlreadyExists(Voter voter)
        {
            if (RetrieveByEmailAddress(voter.EmailAddress) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddVoterIfNonExisting(Voter voter)
        {
            if (voter != null && !VoterAlreadyExists(voter))
            {
                StoreVoter(voter);
            }
        }

        public void UpdateVoterDetails(Voter originalVoter, Voter newVoter)
        {
            if (originalVoter != null && newVoter != null)
            {
                originalVoter.LastName = newVoter.LastName;
                originalVoter.FirstName = newVoter.FirstName;
                originalVoter.EmailAddress = newVoter.EmailAddress;
                UpdateVoter(originalVoter);
            }
        }

        public Voter CreateNewVoter(string lastName, string firstName, string emailAddress)
        {
            Voter voter = new Voter(lastName, firstName, emailAddress);
            return voter;
        }
        #endregion
    }
}