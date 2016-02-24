using System;
using HMSWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HMSWebApp.Tests.Models
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //Arrange
            User user = new User();
            user.FirstName = "Bilbo";
            user.LastName = "Baggins";

            string expected = "Baggins, Bilbo";

            //Act
            string actual = user.FullName;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //Arrange
            User user = new User();
            user.LastName = "Baggins";

            string expected = "Baggins";

            //Act
            string actual = user.FullName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //Arrange
            User user = new User();
            user.FirstName = "Bilbo";

            string expected = "Bilbo";

            //Act
            string actual = user.FullName;

            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
