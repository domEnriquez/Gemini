using System.Collections.Generic;
using System.Web.Mvc;
using HMSWebApp.Common;
using HMSWebApp.Models;
using HMSWebApp.Repository;
using HMSWebApp.ViewModels;

namespace HMSWebApp.Controllers
{
    public class VoteEntryController : Controller
    {
        VoteEventsViewModel voteEvents = new VoteEventsViewModel();

        /// <summary>
        ///  Returns a view with a list of VoteEntryViewModel entities
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAll()
        {
            return View(voteEvents.RetrieveAll());
        }

        [HttpGet]
        public ActionResult Encode()
        {
            var voteEntryViewModel = new VoteEntryViewModel();
            voteEntryViewModel.PrepareViewResources();
            return View(voteEntryViewModel);
        }

        [HttpPost]
        public ActionResult Encode(VoteEntryViewModel voteEntry)
        {
            if (ModelState.IsValid)
            {
                voteEvents.Encode(voteEntry);
            }

            return RedirectToAction("ViewAll");
        }

        public ActionResult Delete(int voteEntryId)
        {
            voteEvents.DeleteVoteEntry(voteEntryId);
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Edit(int voteEntryId)
        {
            VoteEntryViewModel voteEntryViewModel = voteEvents.RetrieveSingle(voteEntryId);
            if (voteEntryViewModel == null)
            {
                return HttpNotFound();
            }
            else voteEntryViewModel.PrepareViewResources();

            return View(voteEntryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(VoteEntryViewModel voteEntry) 
        {
            voteEvents.UpdateVoteEntry(voteEntry);
            return RedirectToAction("ViewAll");
        }

    }
}
