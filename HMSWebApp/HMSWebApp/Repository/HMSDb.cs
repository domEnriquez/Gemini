using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class HMSDb : DbContext
    {
        public HMSDb()
            : base("name=DefaultConnection")
        {

        }

        /// <summary>
        ///  DbSet for VoteEntry
        /// </summary>
        public DbSet<VoteEntry> VoteEntry { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Voter> Voter { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}