namespace HMSWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HMSWebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HMSWebApp.Repository.HMSDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HMSWebApp.Repository.HMSDb context)
        {
            //context.VoteEntry.AddOrUpdate(r => r.Id,
            //    new VoteEntry(1)
            //    {
            //        VoterId = 1,
            //        TeamId = 1,
            //        Type = "Internal",
            //        Payment =
            //            new Payment(1)
            //            {
            //                Amount = 100.00,
            //                Currency = "Php",
            //                PesoEquivalent = 100.00
            //            }
            //    });
            //context.VoteEntry.AddOrUpdate(r => r.Id,
            //    new VoteEntry(2)
            //    {
            //        VoterId = 1,
            //        TeamId = 2,
            //        Type = "External",
            //        Payment =
            //            new Payment(2)
            //            {
            //                Amount = 200.00,
            //                Currency = "Php",
            //                PesoEquivalent = 200.00
            //            }
            //    });
            //context.Voter.AddOrUpdate(r => r.LastName,
            //    new Voter(1)
            //    {
            //        LastName = "Enriquez",
            //        FirstName = "Dominic",
            //        EmailAddress = "dominicjosephenriquez@gmail.com"
            //    });
            //context.Team.AddOrUpdate(r => r.Name,
            //    new Team(1)
            //    {
            //        Name = "Shohoku",
            //        VideoFileName = "ShohokuVSRyonan.mp4"
            //    });
            //context.Team.AddOrUpdate(r => r.Name,
            //    new Team(2)
            //    {
            //        Name = "OnePiece",
            //        VideoFileName = "LuffyVSDoflamingo.mp4"
            //    });
        }
    }
}
