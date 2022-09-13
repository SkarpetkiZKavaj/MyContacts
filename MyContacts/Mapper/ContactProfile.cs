using AutoMapper;
using MyContacts_BAL.DTO;
using MyContacts_DAL.Models;
using MyContacts.Models;

namespace MyContacts.Mapper;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactDTO, Contact>().ReverseMap();
        CreateMap<ContactDTO, ContactViewModel>().ReverseMap();
    }
}