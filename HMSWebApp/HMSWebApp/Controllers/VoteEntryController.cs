﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSWebApp.Models;
using HMSWebApp.Repository;
using HMSWebApp.ViewModels;

namespace HMSWebApp.Controllers
{
    public class VoteEntryController : Controller
    {

        VoteEntryRepository _voteEntryDb = new VoteEntryRepository(); 

        /// <summary>
        ///  Returns a view with a list of VoteEntryViewModel entities
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAll()
        {
            var voteEntryViewModelList = _voteEntryDb.RetrieveAllVoteEntriesViewModel();
            return View(voteEntryViewModelList);
        }

        [HttpGet]
        public ActionResult Encode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Encode(VoteEntryViewModel voteEntry)
        {
            //Checks if the model binding is successful. If it didn't violate any violation rules
            if (ModelState.IsValid)
            {
                _voteEntryDb.Encode(voteEntry);
            }

            return View(voteEntry);
        }

        [HttpPost]
        public ActionResult Delete(int voteEntryId)
        {
            _voteEntryDb.DeleteVoteEntryViewModel(voteEntryId);
            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Edit(int voteEntryId)
        {
            var voteEntryViewModel = _voteEntryDb.RetrieveSingleVoteEntryViewModel(voteEntryId);
            if (voteEntryViewModel == null)
            {
                return HttpNotFound();
            }
            return View(voteEntryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(VoteEntryViewModel voteEntry) 
        {
            _voteEntryDb.UpdateVoteEntryViewModel(voteEntry);
            return RedirectToAction("ViewAll");
        }

    }
}
