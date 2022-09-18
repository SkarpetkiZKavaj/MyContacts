using MyContacts_DAL.EF;

namespace MyContacts_DAL;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private ContactsContext _context;
    private bool _disposed = false;
    private Repository _contactRepository;

    public UnitOfWork(ContactsContext context)
    {
        this._context = context;
    }


    public Repository ContactRepository
    {
        get
        {
            if (_contactRepository is null)
                _contactRepository = new Repository(_context);
 
            return _contactRepository;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        
        this._disposed = true;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}