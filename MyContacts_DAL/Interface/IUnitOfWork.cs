namespace MyContacts_DAL;

public interface IUnitOfWork
{
    public Repository ContactRepository { get; }

    public void Save();
    
    public void Dispose();
}