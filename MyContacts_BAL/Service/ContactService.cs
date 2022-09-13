using AutoMapper;
using MyContacts_BAL.DTO;
using MyContacts_BAL.Interface;
using MyContacts_DAL.Interface;
using MyContacts_DAL.Models;

namespace MyContacts_BAL.Service;

public class ContactService : IService
{
    private readonly IMapper _mapper;

    private IRepository Database { get; set; }

    public ContactService(IRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        Database = repository;
    }

    public void Create(ContactDTO contact)
    {
        Database.Create(_mapper.Map<ContactDTO, Contact>(contact));
    }

    public IEnumerable<ContactDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(Database.GetAll());
    }

    public ContactDTO GetById(int id)
    {
        return _mapper.Map<Contact, ContactDTO>(Database.GetById(id));
    }

    public void Update(ContactDTO contact)
    {
        Database.Update(_mapper.Map<ContactDTO, Contact>(contact));
    }

    public void Delete(int id)
    {
        Database.Delete(id);
    }

    public void Save()
    {
        Database.Save();
    }
}