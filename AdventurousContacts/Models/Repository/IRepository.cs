using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdventurousContacts.Models;

namespace AdventurousContacts.Models.Repository
{
    public interface IRepository : IDisposable
    {
        void Add(Contact contact); 

        void Delete(Contact contact);

        IQueryable<Contact> FindAllContacts();

        Contact GetContactById(int contactId);

        List<Contact> GetLastContacts(int count = 20);

        void Save();

        void Update(Contact contact);

    }
}