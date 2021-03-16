using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidD.DataAccess;
using RapidD.Repository.Interface;

namespace RapidD.Repository
{
    public class ContactRepo : IContact
    {
        private RapidDEntities _context;

        public ContactRepo(RapidDEntities context)
        {
            this._context = context;
        }

        public void CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public Contact GetContact(int contactId)
        {
            return _context.Contacts.Find(contactId);
        }

        public IEnumerable<Contact> GetContacts(int userId)
        {
            return _context.Contacts.Where(u => u.UserId == userId && u.IsActive == true);
        }

        public void UpdateContact(Contact contact)
        {
            _context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteContact(int contactId)
        {
            Contact contact = GetContact(contactId);
            _context.Contacts.Remove(contact);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
