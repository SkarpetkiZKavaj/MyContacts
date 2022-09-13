using Microsoft.EntityFrameworkCore;
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
            var sqlitePath = @"Data Source=" + Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"MyContacts_DAL/Contacts.db;");
            
            optionsBuilder.UseSqlite(sqlitePath);
        }
    } 
}