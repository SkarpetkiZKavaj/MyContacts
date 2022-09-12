using MyContacts_DAL.Models;

namespace MyContacts_DAL.Interface;

public interface IRepository
{
    public void Create(Contact contact);
    
    public IEnumerable<Contact> GetAll();

    public Contact GetById(int id);

    public void Update(Contact contact);

    public void Delete(int id);

    public void Save();
}