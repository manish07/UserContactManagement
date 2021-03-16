using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidD.Data;
using RapidD.DataAccess;
using RapidD.Repository.Interface;
using RapidD.Repository;

namespace RapidD.BusinessLogic
{
    public class ContactManagement
    {
        private IContact _contactRepo;

        public ContactManagement()
        {
            this._contactRepo = new ContactRepo(new RapidDEntities());
        }

        public int CreateContact(ContactModel model)
        {
            Contact contact = new Contact();
            contact.UserId = model.UserId;
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Address = model.Address;
            contact.Email = model.Email;
            contact.Mobile = model.Mobile;
            contact.IsActive = true;

            _contactRepo.CreateContact(contact);
            try
            {
                _contactRepo.Save();
            }
            catch (Exception)
            {
                throw;
            }           
            return contact.ContactId;
        }

        public int UpdateContact(ContactModel model)
        {
            Contact contact = _contactRepo.GetContact(model.ContactId);
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Address = model.Address;
            contact.Email = model.Email;
            contact.Mobile = model.Mobile;
            
            _contactRepo.UpdateContact(contact);
            try
            {
                _contactRepo.Save();
            }
            catch
            {
                throw;
            }
            return model.ContactId;
        }

        public ContactModel GetContact(int contactId)
        {
            Contact contact = _contactRepo.GetContact(contactId);
            ContactModel model = GetContact(contact);
            return model;
        }

        private ContactModel GetContact(Contact contact)
        {
            ContactModel model = new ContactModel();

            model.ContactId = contact.ContactId;
            model.UserId = contact.UserId;
            model.FirstName = contact.FirstName;
            model.LastName = contact.LastName;
            model.Address = contact.Address;
            model.Email = contact.Email;
            model.Mobile = contact.Mobile;
            model.ContactId = contact.ContactId;
            model.IsActive = contact.IsActive;
            return model;
        }

        public List<ContactModel> GetContacts(int userId)
        {
            return _contactRepo.GetContacts(userId).Select(m => GetContact(m)).ToList();
        }

        public void DeleteContact(int contactId)
        {
            // _contactRepo.DeleteContact(contactId);
            Contact contact = _contactRepo.GetContact(contactId);
            contact.IsActive = false;
            try
            {
                _contactRepo.Save();
            }
            catch
            {
                throw;
            }
        }
    }
}
