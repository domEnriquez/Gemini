using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSWebApp.Models;
using HMSWebApp.Repository;

namespace HMSWebApp.Controllers
{
    public class VoteEntryController : Controller
    {

        VoteEntryRepository _voteEntryDb = new VoteEntryRepository(); 

        /// <summary>
        ///  Returns a view with a list of all vote entries
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAll()
        {
            var voteEntriesToDisplay = _voteEntryDb.RetrieveMultipleVoteEntryDisplay();
            return View(voteEntriesToDisplay);
        }

        [HttpGet]
        public ActionResult Encode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Encode(VoteEntryDisplay voteEntryDisplay)
        {
            //Checks if the model binding is successful. If it didn't violate any violation rules
            if (ModelState.IsValid)
            {
                _voteEntryDb.Encode(voteEntryDisplay);
            }

            return View(voteEntryDisplay);
        }

    }
}
