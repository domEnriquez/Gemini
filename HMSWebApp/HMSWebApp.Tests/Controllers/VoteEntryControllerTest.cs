using System;
using System.Collections.Generic;
using HMSWebApp.Controllers;
using HMSWebApp.Models;
using HMSWebApp.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HMSWebApp.Tests.Controllers
{
    [TestClass]
    public class VoteEntryControllerTest
    {
        [TestMethod]
        public void ViewAllVoteEntryTest()
        {
            ////Arrange
            //VoteEntryRepository _voteEntryDb = new VoteEntryRepository(); 

            //List<VoteEntryDisplay> expectedVoteEntriesDisplay = new List<VoteEntryDisplay>();
            //List<VoteEntryDisplay> actualVoteEntriesDisplay = new List<VoteEntryDisplay>();

            //VoteEntryDisplay voteEntryDisplay1 = new VoteEntryDisplay();
            //voteEntryDisplay1.VoterName = "Enriquez, Dominic";
            //voteEntryDisplay1.TeamName = "Shohoku";
            //voteEntryDisplay1.VoterEmailAddress = "dominicjosephenriquez@gmail.com";
            //voteEntryDisplay1.Payment.Amount = 100.00;
            //voteEntryDisplay1.Payment.Currency = "Php";
            //voteEntryDisplay1.Payment.PesoEquivalent = 100.00;

            //expectedVoteEntriesDisplay.Add(voteEntryDisplay1);

            //VoteEntryDisplay voteEntryDisplay2 = new VoteEntryDisplay();
            //voteEntryDisplay2.VoterName = "Enriquez, Dominic";
            //voteEntryDisplay2.TeamName = "OnePiece";
            //voteEntryDisplay2.VoterEmailAddress = "dominicjosephenriquez@gmail.com";
            //voteEntryDisplay2.Payment.Amount = 200.00;
            //voteEntryDisplay2.Payment.Currency = "Php";
            //voteEntryDisplay2.Payment.PesoEquivalent = 200.00;

            //expectedVoteEntriesDisplay.Add(voteEntryDisplay2);

            ////Act
            //actualVoteEntriesDisplay = _voteEntryDb.RetrieveMultipleVoteEntryDisplay();

            ////Assert
            //CollectionAssert.Equals(expectedVoteEntriesDisplay, actualVoteEntriesDisplay);
            
        }
    }
}
