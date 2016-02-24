using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebApp.Models
{
    public class Team
    {
        public Team()
        {

        }

        public Team(int teamId)
        {
            Id = teamId;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string VideoFileName { get; set; }
    }
}