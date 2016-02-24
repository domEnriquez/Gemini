using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class VoteEntryRepository
    {
        HMSDb _db = new HMSDb();
        private PaymentRepository paymentRepository { get; set; }
        private VoterRepository voterRepository { get; set; }
        private TeamRepository teamRepository { get; set; }

        public VoteEntryRepository()
        {
            paymentRepository = new PaymentRepository();
            voterRepository = new VoterRepository();
            teamRepository = new TeamRepository();
        }

        /// <summary>
        ///  Stores the vote entry to the database
        /// </summary>
        public void Encode(VoteEntryDisplay voteEntryDisplay)
        {
            VoteEntry voteEntry = new VoteEntry();

            //Storing voter details
            voterRepository.AddVoterIfNonExisting(voteEntryDisplay.Voter);

            //Getting team details
            var team = teamRepository.RetrieveByName(voteEntryDisplay.TeamName);


            if (voteEntryDisplay != null && team != null)
            {
                voteEntry.VoterId = voteEntryDisplay.Voter.Id;
                voteEntry.TeamId = team.Id;
                voteEntry.Payment = voteEntryDisplay.Payment;
                voteEntry.Type = voteEntryDisplay.VoteEntryType;

                StoreVoteEntry(voteEntry);
            }

        }

        public List<VoteEntry> RetrieveAll()
        {
            List<VoteEntry> voteEntries = _db.VoteEntry.ToList();
            return voteEntries;
        }


        /// <summary>
        ///  Edits a vote entry
        /// </summary>
        public void Edit(int voteEntryId)
        {

        }

        /// <summary>
        ///  Deletes a vote entry
        /// </summary>
        /// <param name="voteEntryId"></param>
        public void Delete(int voteEntryId)
        {
        }

        /// <summary>
        ///  Retrieves a VoteEntryDisplay object that contains all the necessary information to be shown to the user
        /// </summary>
        /// <returns></returns>
        public VoteEntryDisplay RetrieveVoteEntryDisplay()
        {
            VoteEntryDisplay voteEntryDisplay = new VoteEntryDisplay();
            
            return voteEntryDisplay;
        }

        /// <summary>
        ///  Retrieves a list of VoteEntryDisplay object
        /// </summary>
        /// <returns></returns>
        public List<VoteEntryDisplay> RetrieveMultipleVoteEntryDisplay()
        {
            List<VoteEntryDisplay> voteEntriesDisplay = new List<VoteEntryDisplay>();

            var voteEntries = RetrieveAll();

            foreach (var voteEntry in voteEntries)
            {
                VoteEntryDisplay voteEntryDisplay = new VoteEntryDisplay();
                voteEntryDisplay.Voter = voterRepository.Retrieve(voteEntry.VoterId);
                voteEntryDisplay.TeamName = teamRepository.RetrieveById(voteEntry.TeamId).Name;
                voteEntryDisplay.Payment = voteEntry.Payment;
                voteEntriesDisplay.Add(voteEntryDisplay);
            }

            return voteEntriesDisplay;
        }


        private void StoreVoteEntry(VoteEntry voteEntry)
        {
            if (voteEntry != null)
            {
                _db.VoteEntry.Add(voteEntry);
                _db.SaveChanges();
            }
        }


        public void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }

    }
}