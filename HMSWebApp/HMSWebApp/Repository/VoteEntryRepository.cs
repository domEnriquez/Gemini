using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSWebApp.Common;
using HMSWebApp.Enums;
using HMSWebApp.Models;
using HMSWebApp.ViewModels;

namespace HMSWebApp.Repository
{
    /// <summary>
    ///  Data logic class for handling add/delete/update of vote entry objects in the database
    /// </summary>
    public class VoteEntryRepository
    {
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

        #region Counstructor

        /// <summary>
        ///  VoteEntryRepository constructor
        /// </summary>
        public VoteEntryRepository()
        {
            paymentRepository = new PaymentRepository();
            voterRepository = new VoterRepository();
            teamRepository = new TeamRepository();
        }

        #endregion

        #region Public methods

        /// <summary>
        ///  Stores the vote entry to the database
        /// </summary>
        public void Encode(VoteEntryViewModel voteEntryViewModel)
        {
            using (var _db = new HMSDb())
            {
                if (voteEntryViewModel != null)
                {
                    var voter = voterRepository.CreateNewVoter(voteEntryViewModel.VoterLastName, voteEntryViewModel.VoterFirstName, voteEntryViewModel.VoterEmailAddress);
                    if (!voterRepository.VoterAlreadyExists(voter))
                    {
                        voterRepository.AddVoter(voter);
                    }
                    else
                    {
                        voter = voterRepository.RetrieveByEmailAddress(voter.EmailAddress);
                    }

                    var voteEntry = ConvertToVoteEntryEntity(voteEntryViewModel, voter);
                    StoreVoteEntry(voteEntry);
                }
            }
        }

        public List<VoteEntryViewModel> RetrieveAllVoteEntriesViewModel()
        {
            List<VoteEntryViewModel> voteEntryViewModelList = new List<VoteEntryViewModel>();
            //Retrieving all voteEntry objects
            var voteEntries = RetrieveAll();
            foreach (var voteEntry in voteEntries)
            {
                var voter = voterRepository.RetrieveById(voteEntry.VoterId);
                var voteEntryViewModel = ConvertToVoteEntryviewModel(voteEntry, voter);
                voteEntryViewModelList.Add(voteEntryViewModel);
            }
            return voteEntryViewModelList;
        }


        public VoteEntryViewModel RetrieveSingleVoteEntryViewModel(int voteEntryId)
        {
            VoteEntry voteEntry = RetrieveSingleVoteEntry(voteEntryId);
            var voter = voterRepository.RetrieveById(voteEntry.VoterId);
            var voteEntryViewModel = ConvertToVoteEntryviewModel(voteEntry, voter);
            return voteEntryViewModel;
        }

        public void UpdateVoteEntryViewModel(VoteEntryViewModel voteEntryViewModel)
        {
            VoteEntry voteEntry = RetrieveSingleVoteEntry(voteEntryViewModel.VoteEntryId);
            var originalVoter = voterRepository.RetrieveById(voteEntry.VoterId);
            var newVoter = voterRepository.CreateNewVoter(voteEntryViewModel.VoterLastName, voteEntryViewModel.VoterFirstName, voteEntryViewModel.VoterEmailAddress);
            voterRepository.UpdateVoterDetails(originalVoter, newVoter);
            UpdateVoteEntry(voteEntry, voteEntryViewModel);
        }

        private void UpdateVoteEntry(VoteEntry voteEntry, VoteEntryViewModel voteEntryViewModel)
        {
            voteEntry.Type = EnumHelper.GetName<VoteEntryTypes>(voteEntryViewModel.VoteEntryType);
            voteEntry.TeamId = voteEntryViewModel.TeamId;
            voteEntry.Payment.Amount = voteEntryViewModel.PaymentAmount;
            voteEntry.Payment.Currency = EnumHelper.GetName<PaymentCurrencies>(voteEntryViewModel.PaymentCurrency);
            voteEntry.Payment.PesoEquivalent = voteEntryViewModel.PaymentPesoEquivalent;
            UpdateVoteEntry(voteEntry);
        }

        public void DeleteVoteEntryViewModel(int voteEntryId)
        {
            VoteEntry voteEntry = RetrieveSingleVoteEntry(voteEntryId);
            DeleteVoteEntry(voteEntry);
        }

        public VoteEntryViewModel PrepareViewDataResources(VoteEntryViewModel voteEntryViewModel)
        {
            voteEntryViewModel.Teams = teamRepository.RetrieveAll().Select(x =>
                                            new SelectListItem{
                                                Text = x.Name,
                                                Value = x.Id.ToString()
                                            });
            voteEntryViewModel.VoteEntryTypes = EnumHelper.GetEnumSelectList<VoteEntryTypes>();
            voteEntryViewModel.PaymentCurrencies = EnumHelper.GetEnumSelectList<PaymentCurrencies>();

            return voteEntryViewModel;
        }


        #endregion

        #region Private Methods

        private VoteEntryViewModel ConvertToVoteEntryviewModel(VoteEntry voteEntry, Voter voter)
        {
            VoteEntryViewModel voteEntryViewModel = new VoteEntryViewModel();

            voteEntryViewModel.VoteEntryId = voteEntry.Id;
            voteEntryViewModel.VoteEntryType = voteEntry.Type;
            voteEntryViewModel.VoterLastName = voter.LastName;
            voteEntryViewModel.VoterFirstName = voter.FirstName;
            voteEntryViewModel.VoterEmailAddress = voter.EmailAddress;
            voteEntryViewModel.PaymentAmount = voteEntry.Payment.Amount;
            voteEntryViewModel.PaymentCurrency = voteEntry.Payment.Currency;
            voteEntryViewModel.PaymentPesoEquivalent = voteEntry.Payment.PesoEquivalent;
            voteEntryViewModel.TeamId = voteEntry.TeamId;
            voteEntryViewModel.TeamName = teamRepository.RetrieveTeamName(voteEntry.TeamId);

            return voteEntryViewModel;
        }

        private VoteEntry ConvertToVoteEntryEntity(VoteEntryViewModel voteEntryViewModel, Voter voter)
        {
            VoteEntry voteEntry = new VoteEntry(voteEntryViewModel.VoteEntryId);
            voteEntry.Type = EnumHelper.GetName<VoteEntryTypes>(voteEntryViewModel.VoteEntryType);
            voteEntry.TeamId = voteEntryViewModel.TeamId;
            voteEntry.Payment = new Payment(voteEntryViewModel.PaymentAmount, EnumHelper.GetName<PaymentCurrencies>(voteEntryViewModel.PaymentCurrency), voteEntryViewModel.PaymentPesoEquivalent);
            voteEntry.VoterId = voter.Id;
            return voteEntry;
        }

        private List<VoteEntry> RetrieveAll()
        {
            using (var _db = new HMSDb())
            {
                List<VoteEntry> voteEntries = _db.VoteEntry.AsNoTracking().Include("Payment").ToList();
                return voteEntries;
            }
        }

        private void StoreVoteEntry(VoteEntry voteEntry)
        {
            using (var _db = new HMSDb())
            {
                if (voteEntry != null)
                {
                    _db.VoteEntry.Add(voteEntry);
                    _db.SaveChanges();
                }
            }
        }

        private VoteEntry RetrieveSingleVoteEntry(int voteEntryId)
        {
            using (var _db = new HMSDb())
            {
                if (voteEntryId != null)
                {
                    var voteEntry = _db.VoteEntry.Include("Payment").FirstOrDefault(entry => entry.Id == voteEntryId);
                    return voteEntry;
                }
            }
            return null;
        }

        private void UpdateVoteEntry(VoteEntry voteEntry)
        {
            using (var _db = new HMSDb())
            {
                _db.Entry(voteEntry).State = EntityState.Modified;
                _db.Entry(voteEntry.Payment).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        private void DeleteVoteEntry(VoteEntry voteEntry)
        {
            using (var _db = new HMSDb())
            {
                _db.Entry(voteEntry).State = EntityState.Deleted;
                _db.SaveChanges();
            }
        }
        #endregion
    }
}