using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Models;

namespace HMSWebApp.Repository
{
    public class UserRepository
    {
        /// <summary>
        ///  Retrieves a user from the database
        /// </summary>
        /// <returns></returns>
        public User Retrieve()
        {
            User user = new User();

            return user;
        }

        /// <summary>
        ///  Saves a user into the database
        /// </summary>
        /// <param name="userId">Identifier of the user</param>
        public void Save(int userId)
        {

        }

        /// <summary>
        ///  Edits a user
        /// </summary>
        /// <param name="userId">Identifier of the user to be edited</param>
        public void Edit(int userId)
        {

        }


    }
}