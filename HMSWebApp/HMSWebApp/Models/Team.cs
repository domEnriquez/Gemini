using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HMSWebApp.Enums;
using HMSWebApp.Interfaces;

namespace HMSWebApp.Models
{
    public class Team : IObjectWithState
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

        [NotMapped]
        public State State { get; set; }
    }
}