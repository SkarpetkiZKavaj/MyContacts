using MyContacts_DAL.EF;

namespace MyContacts_DAL;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private ContactsContext context;
    private bool disposed = false;
    private Repository contactRepository;

    public UnitOfWork(ContactsContext context)
    {
        this.context = context;
    }


    public Repository ContactRepository
    {
        get
        {
            if (contactRepository is null)
                contactRepository = new Repository(context);
 
            return contactRepository;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
            if (disposing)
                context.Dispose();
        
        this.disposed = true;
    }

    public void Save()
    {
        context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}