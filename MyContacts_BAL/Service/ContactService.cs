using AutoMapper;
using MyContacts_BAL.DTO;
using MyContacts_BAL.Interface;
using MyContacts_DAL;
using MyContacts_DAL.Models;

namespace MyContacts_BAL.Service;

public class ContactService : IDisposable ,IService
{
    private bool _disposed = false;
    private readonly IMapper _mapper;
    private IUnitOfWork Database { get; set; }

    public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        Database = unitOfWork;
    }

    public void Create(ContactDTO contact)
    {
        Database.ContactRepository.Create(_mapper.Map<ContactDTO, Contact>(contact));
        Database.Save();
    }

    public IEnumerable<ContactDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(Database.ContactRepository.GetAll());
    }

    public ContactDTO GetById(int id)
    {
        return _mapper.Map<Contact, ContactDTO>(Database.ContactRepository.GetById(id));
    }

    public void Update(ContactDTO contact)
    {
        Database.ContactRepository.Update(_mapper.Map<ContactDTO, Contact>(contact));
        Database.Save();
    }

    public void Delete(int id)
    {
        Database.ContactRepository.Delete(id);
        Database.Save();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
            {
                Database.Dispose();
            }

        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}