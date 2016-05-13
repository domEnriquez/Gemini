using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSWebApp.Common;
using HMSWebApp.Enums;
using HMSWebApp.Models;
using HMSWebApp.Repository;

namespace HMSWebApp.ViewModels
{
    public class VoteEventsViewModel
    {
        #region Properties

        VoteEntryViewModel voteEntryViewModel { get; set; }
        VoteEntryRepository voteEntryRepo { get; set; }
        VoterRepository voterRepo { get; set; }
        TeamRepository teamRepo { get; set; }
        PaymentRepository paymentRepo { get; set; }

        #endregion

        #region Public Methods

        public List<VoteEntryViewModel> RetrieveAll()
        {
            List<VoteEntryViewModel> voteEntryViewModelList = new List<VoteEntryViewModel>();
            using (UnitOfWorkHms uow = new UnitOfWorkHms())
            {
                voteEntryRepo = new VoteEntryRepository(uow);
                var voteEntries = voteEntryRepo.AllIncluding(new string[] { "Payment" }).ToList();

                teamRepo = new TeamRepository(uow);
                voterRepo = new VoterRepository(uow);
                foreach (var voteEntry in voteEntries)
                {
                    Team team = teamRepo.Find(voteEntry.TeamId);
                    Voter voter = voterRepo.Find(voteEntry.VoterId);
                    voteEntryViewModel = VoteEntryMapper.ConvertToVoteEntryViewModel(voteEntry, voter, team);
                    voteEntryViewModelList.Add(voteEntryViewModel);
                }
            }
            return voteEntryViewModelList;
        }

        public VoteEntryViewModel RetrieveSingle(int voteEntryId)
        {
            using (UnitOfWorkHms uow = new UnitOfWorkHms())
            {
                voteEntryRepo = new VoteEntryRepository(uow);
                VoteEntry voteEntry = voteEntryRepo.SingleIncluding(voteEntryId, new string[] { "Payment" });
                voterRepo = new VoterRepository(uow);
                Voter voter = voterRepo.Find(voteEntry.VoterId);
                teamRepo = new TeamRepository(uow);
                Team team = teamRepo.Find(voteEntry.TeamId);
                voteEntryViewModel = VoteEntryMapper.ConvertToVoteEntryViewModel(voteEntry, voter, team);
                return voteEntryViewModel;
            }
        }

        public void Encode(VoteEntryViewModel voteEntryViewModel)
        {
            if (voteEntryViewModel != null)
            {
                var voter = new Voter(voteEntryViewModel.VoterLastName, voteEntryViewModel.VoterFirstName, voteEntryViewModel.VoterEmailAddress);
                using (UnitOfWorkHms uow = new UnitOfWorkHms())
                {
                    voterRepo = new VoterRepository(uow);
                    if (voterRepo.VoterAlreadyExists(voter))
                    {
                        voter = voterRepo.FindByEmailAddress(voter.EmailAddress);
                    }
                    else
                    {
                        voterRepo.InsertGraph(voter);
                        uow.Save();
                    }
                    var voteEntry = VoteEntryMapper.ConvertToVoteEntryEntity(voteEntryViewModel, voter);
                    voteEntryRepo = new VoteEntryRepository(uow);
                    voteEntryRepo.InsertGraph(voteEntry);
                    uow.Save();
                }
            }
        }

        public void DeleteVoteEntry(int voteEntryId)
        {
            using (UnitOfWorkHms uow = new UnitOfWorkHms())
            {
                voteEntryRepo = new VoteEntryRepository(uow);
                var voteEntry = voteEntryRepo.SingleIncluding(voteEntryId, new string[] { "Payment" });
                paymentRepo = new PaymentRepository(uow);
                paymentRepo.Delete(voteEntry.Payment);
                voteEntryRepo.Delete(voteEntry);
                uow.Save();
            }
        }

        public void UpdateVoteEntry(VoteEntryViewModel voteEntryViewModel)
        {
            using (UnitOfWorkHms uow = new UnitOfWorkHms())
            {
                var voteEntryRepo = new VoteEntryRepository(uow);
                VoteEntry originalVoteEntry = voteEntryRepo.SingleIncluding(voteEntryViewModel.VoteEntryId, new string[] { "Payment" });
                var voterRepo = new VoterRepository(uow);
                Voter originalVoter = voterRepo.Find(originalVoteEntry.VoterId);
                var updatedVoter = new Voter(voteEntryViewModel.VoterLastName, voteEntryViewModel.VoterFirstName, voteEntryViewModel.VoterEmailAddress);
                originalVoter = UpdateVoter(voterRepo, originalVoter, updatedVoter);
                VoteEntry newVoteEntry = VoteEntryMapper.ConvertToVoteEntryEntity(voteEntryViewModel, originalVoter);
                originalVoteEntry = VoteEntryMapper.MapVoteEntryDetails(originalVoteEntry, newVoteEntry);
                voteEntryRepo.Update(originalVoteEntry);
                paymentRepo = new PaymentRepository(uow);
                paymentRepo.Update(originalVoteEntry.Payment);
                uow.Save();
            }
        }


        public Voter UpdateVoter(VoterRepository voterRepo, Voter originalVoter, Voter updatedVoter)
        {
            originalVoter = VoteEntryMapper.MapVoterDetails(originalVoter, updatedVoter);
            voterRepo.Update(originalVoter);
            return originalVoter;
        }


        #endregion
    }
}