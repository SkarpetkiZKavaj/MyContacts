using AutoMapper;
using MyContacts_BAL.DTO;
using MyContacts_DAL.Models;
using MyContacts.Models;

namespace MyContacts.Mapper;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactDTO>().ReverseMap()            
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
            .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone));

        CreateMap<ContactDTO, ContactViewModel>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateOnly.ParseExact(src.BirthDate, "d/M/yyyy")))
            .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
            .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone));
    }
}