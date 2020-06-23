using System.Collections.Generic;
using System.Threading.Tasks;

namespace address_book_ggs_training.Entities
{
    public interface IContactsManager
    {
        Contact AddContact(Contact contact);
        List<Contact> GetContacts(int skip = 0, int? take = null);
        List<ContactShort> GetContactsShort(int skip = 0, int? take = null);
        bool RemoveContact(int id);
        Contact GetContactById(int id);
        Contact UpdateContact(int id, Contact newContact);

        Task<Contact> AddContactAsync(Contact contact);
        Task<List<Contact>> GetContactsAsync(int skip = 0, int? take = null);
        Task<List<ContactShort>> GetContactsShortAsync(int skip = 0, int? take = null);
        Task<bool> RemoveContactAsync(int id);
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> UpdateContactAsync(int id, Contact newContact);
    }
}