using AutoMapper;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;

namespace Portfolio.API.Mapping
{
    public class ExperienceMapping : Profile
    {
        public ExperienceMapping() { 
            CreateMap<Experience,ExperienceDto>().ReverseMap();
        }
    }
}
