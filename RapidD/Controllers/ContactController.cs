using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RapidD.Data;
using RapidD.BusinessLogic;

namespace RapidD.Controllers
{
    public class ContactController : Controller
    {
        private ContactManagement _contactManagement = new ContactManagement();
        // GET: Contact
        public ActionResult Index()
        {
            ContactModel model = new ContactModel();
            model.ContactCollection = _contactManagement.GetContacts(model.UserId);
            return View(model);
        }

        public ActionResult GetContact(int contactId)
        {
            ContactModel model = _contactManagement.GetContact(contactId);
            return View("~/Views/Contact/_ContactForm.cshtml", model);
        }

        public ActionResult GetContacts(int userId)
        {
            ContactModel model = new ContactModel();
            model.ContactCollection = _contactManagement.GetContacts(userId);
            return View("~/Views/Contact/Index.cshtml", model);
        }

        public ActionResult SaveContact(ContactModel model)
        {
            if(ModelState.IsValid)
            {
                int contactId = model.ContactId > 0 ? _contactManagement.UpdateContact(model) : _contactManagement.CreateContact(model);
                if (contactId > 0)
                {
                    model.ContactId = contactId;
                    return RedirectToAction("GetContacts", new { userId = model.UserId });
                }
            }
            model.ContactCollection = _contactManagement.GetContacts(model.UserId);
            return PartialView("~/Views/Contact/Index.cshtml", model);
        }

        public ActionResult EditContact(int contactId)
        {
            ContactModel model = _contactManagement.GetContact(contactId);
            return PartialView("~/Views/Contact/_ContactForm.cshtml", model);
        }

        public ActionResult DeleteContact(int contactId, int userId)
        {
            _contactManagement.DeleteContact(contactId);
            return RedirectToAction("RefreshContactList", new { userId = userId });
        }

        public ActionResult RefreshContactList(int userId)
        {
            ContactModel model = new ContactModel();
            model.ContactCollection = _contactManagement.GetContacts(userId);
            return PartialView("~/Views/Contact/_ContactList.cshtml", model);
        }


    }
}