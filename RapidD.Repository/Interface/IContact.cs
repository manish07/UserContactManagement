using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidD.DataAccess;

namespace RapidD.Repository.Interface
{
    public interface IContact
    {
        void CreateContact(Contact contact);
        Contact GetContact(int contactId);
        void UpdateContact(Contact contact);
        void DeleteContact(int contactId);
        IEnumerable<Contact> GetContacts(int userId);
        void Save();
    }
}
