using Microsoft.EntityFrameworkCore;
using MyContacts_DAL.Models;

namespace MyContacts_DAL.EF;

public class ContactsContext : DbContext
{
    public virtual DbSet<Contact> Contacts { get; set; }

    ContactsContext()
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite();
        }
    }
}