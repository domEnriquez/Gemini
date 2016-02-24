using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebApp.Models
{
    public class User
    {

        #region Properties

        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int TeamId { get; set; }
        public string Type { get; set; }

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
        #endregion

    }
}