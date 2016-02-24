using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    /// <summary>
    ///  Data logic class for handling add/delete/update of vote entry objects in the database
    /// </summary>
    public class VoteEntryRepository
    {
        HMSDb _db = new HMSDb();

        #region Fields

        /// <summary>
        ///  PaymentRepository object for add/delete/update of payment objects in the database
        /// </summary>
        private PaymentRepository paymentRepository { get; set; }

        /// <summary>
        ///  PaymentRepository object for add/delete/update of voter objects in the database
        /// </summary>
        private VoterRepository voterRepository { get; set; }

        /// <summary>
        ///  PaymentRepository object for add/delete/update of team objects in the database
        /// </summary>
        private TeamRepository teamRepository { get; set; }

        #endregion

        /// <summary>
        ///  VoteEntryRepository constructor
        /// </summary>
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

        /// <summary>
        ///  Retrieces all of vote entry objects stored in the database
        /// </summary>
        /// <returns>List of vote entry objects</returns>
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

        /// <summary>
        ///  Adds a vote entry object into the database
        /// </summary>
        /// <param name="voteEntry"></param>
        private void StoreVoteEntry(VoteEntry voteEntry)
        {
            if (voteEntry != null)
            {
                _db.VoteEntry.Add(voteEntry);
                _db.SaveChanges();
            }
        }

    }
}