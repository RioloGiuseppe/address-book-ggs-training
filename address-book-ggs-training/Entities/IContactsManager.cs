using System.Collections.Generic;

namespace address_book_ggs_training.Entities
{
    public interface IContactsManager
    {
        Contact AddContact(Contact contact);
        List<Contact> GetContacts(int skip = 0, int? take = null);
        List<ContactShort> GetContactsShort(int skip = 0, int? take = null);
        bool RemoveContact(int id);
        Contact UpdateContact(int id, Contact newContact);
    }
}