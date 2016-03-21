using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class TeamRepository
    {
        public Team RetrieveById(int teamId)
        {
            using (var _db = new HMSDb())
            {
                Team team = _db.Team.Find(teamId);
                return team;
            }
        }

        public Team RetrieveByName(string teamName)
        {
            using (var _db = new HMSDb())
            {
                Team team = _db.Team.AsNoTracking().Where(t => t.Name == teamName).FirstOrDefault();
                return team;
            }

        }
    }
}