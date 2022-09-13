namespace MyContacts_BAL.DTO;

public class ContactDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? MobilePhone { get; set; }

    public string? JobTitle { get; set; }

    public DateOnly BirthDate { get; set; }
}