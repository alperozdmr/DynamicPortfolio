using AutoMapper;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;

namespace Portfolio.API.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping() {
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
