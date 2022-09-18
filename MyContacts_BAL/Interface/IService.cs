using MyContacts_BAL.DTO;

namespace MyContacts_BAL.Interface;

public interface IService
{
    public void Create(ContactDTO contact);
    
    public IEnumerable<ContactDTO> GetAll();

    public ContactDTO GetById(int id);

    public void Update(ContactDTO contact);

    public void Delete(int id);
}