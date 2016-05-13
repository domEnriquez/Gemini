using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Enums;
using HMSWebApp.Models;
using HMSWebApp.ViewModels;

namespace HMSWebApp.Common
{
    public static class VoteEntryMapper
    {
        public static VoteEntryViewModel ConvertToVoteEntryViewModel(VoteEntry voteEntry, Voter voter, Team team)
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
            voteEntryViewModel.TeamName = team.Name;

            return voteEntryViewModel;
        }

        public static VoteEntry ConvertToVoteEntryEntity(VoteEntryViewModel voteEntryViewModel, Voter voter)
        {
            VoteEntry voteEntry = new VoteEntry(voteEntryViewModel.VoteEntryId);
            voteEntry.Type = EnumHelper.GetName<VoteEntryTypes>(voteEntryViewModel.VoteEntryType);
            voteEntry.TeamId = voteEntryViewModel.TeamId;
            voteEntry.Payment = new Payment(voteEntryViewModel.PaymentAmount, EnumHelper.GetName<PaymentCurrencies>(voteEntryViewModel.PaymentCurrency), voteEntryViewModel.PaymentPesoEquivalent);
            voteEntry.VoterId = voter.Id;
            return voteEntry;
        }

        public static Voter MapVoterDetails(Voter originalVoter, Voter newVoter)
        {
            originalVoter.LastName = newVoter.LastName;
            originalVoter.FirstName = newVoter.FirstName;
            originalVoter.EmailAddress = newVoter.EmailAddress;
            return originalVoter;
        }

        public static VoteEntry MapVoteEntryDetails(VoteEntry originalVoteEntry, VoteEntry newVoteEntry)
        {
            originalVoteEntry.Type = newVoteEntry.Type;
            originalVoteEntry.TeamId = newVoteEntry.TeamId;
            originalVoteEntry.Payment = MapPaymentDetails(originalVoteEntry.Payment, newVoteEntry.Payment);
            originalVoteEntry.VoterId = newVoteEntry.VoterId;
            return originalVoteEntry;
        }

        public static Payment MapPaymentDetails(Payment originalPayment, Payment newPayment)
        {
            originalPayment.Amount = newPayment.Amount;
            originalPayment.Currency = newPayment.Currency;
            originalPayment.PesoEquivalent = newPayment.PesoEquivalent;
            return originalPayment;
        }
    }
}