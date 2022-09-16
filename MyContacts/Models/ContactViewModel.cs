namespace MyContacts.Models;

public class ContactViewModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? MobilePhone { get; set; }

    public string? JobTitle { get; set; }

    public DateOnly BirthDate { get; set; }

    public bool toUpdate { get; set; } = true;
}