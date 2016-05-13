using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HMSWebApp.Enums;
using HMSWebApp.Interfaces;

namespace HMSWebApp.Models
{
    public class Voter : IObjectWithState
    {
        public Voter() 
        {

        }

        public Voter(int voterId)
        {
            Id = voterId;
        }

        public Voter(string lastName, string firstName, string emailAddress)
        {
            LastName = lastName;
            FirstName = firstName;
            EmailAddress = emailAddress;
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }


        [NotMapped]
        public State State { get; set; }

    }
}