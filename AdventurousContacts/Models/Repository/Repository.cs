using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models.Repository
{
    public class Repository : IRepository
    {
        private bool _disposed = false;
        private AdventureWorksEntities _entities = new AdventureWorksEntities();
          
        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion

        //Returns all contacts from database
        public IQueryable<Contact> FindAllContacts()
        {
            return _entities.Contacts;
        }

        //Delete a contact
        public void Delete(Contact contact)
        {
            _entities.uspRemoveContact(contact.ContactID);
        }

        //Add a contact to the database
        public void Add(Contact contact)
        {
            _entities.uspAddContactEF(contact.FirstName, contact.LastName, contact.EmailAddress);
        }

        //Returns a single contact from database
        public Contact GetContactById(int contactId)
        {
            var contact = _entities.Contacts.Find(contactId);
            return contact;
            
        }

        //Returns a list containing an X number of contacts
        public List<Contact> GetLastContacts(int count = 20)
        {
            var contacts = FindAllContacts().ToList();
            contacts.Reverse();
            return contacts.Take(count).ToList();
        }

        //Updates a contact 
        public void Update(Contact contact)
        {
            _entities.uspUpdateContact(contact.ContactID, contact.FirstName, contact.LastName, contact.EmailAddress);
        }

        //Save all changes to database
        public void Save()
        {
            _entities.SaveChanges();
        }

        
    }
}