using MyContacts_DAL.EF;
using MyContacts_DAL.Models;

namespace MyContacts_DAL;

public class Repository
{
    private ContactsContext _context;

    public Repository(ContactsContext context)
    {
        _context = context;
    }

    public void Create(Contact contact)
    {
        _context.Contacts.Add(contact);
    }

    public IEnumerable<Contact> GetAll()
    {
        return _context.Contacts.ToList();
    }

    public Contact GetById(int id)
    {
        return _context.Contacts.FirstOrDefault(c => c.Id == id);
    }

    public void Update(Contact contact)
    {
        _context.Contacts.Update(contact);
    }

    public void Delete(int id)
    {
        Contact contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

        if (contact is not null)
        {
            _context.Contacts.Remove(contact);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}