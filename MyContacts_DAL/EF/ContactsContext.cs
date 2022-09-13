using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyContacts_DAL.Models;

namespace MyContacts_DAL.EF;

public class ContactsContext : DbContext
{
    public virtual DbSet<Contact> Contacts { get; set; }

    public ContactsContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Filename=Contacts.db");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}