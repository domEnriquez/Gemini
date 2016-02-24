using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class TeamRepository
    {
        HMSDb _db = new HMSDb();

        /// <summary>
        ///  Retrieves a Team object based from the team id
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>Team object</returns>
        public Team RetrieveById(int teamId)
        {
            Team team = _db.Team.Find(teamId);
            return team;
        }

        /// <summary>
        ///  Retrieves a Team object based from the team name
        /// </summary>
        /// <param name="teamName">The name of the team</param>
        /// <returns>Team object</returns>
        public Team RetrieveByName(string teamName)
        {
            Team team = _db.Team.Where(t => t.Name == teamName).FirstOrDefault();
            return team;
        }
    }
}