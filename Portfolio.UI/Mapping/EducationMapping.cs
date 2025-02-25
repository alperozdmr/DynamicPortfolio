using AutoMapper;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;

namespace Portfolio.API.Mapping
{
    public class EducationMapping:Profile
    {
        public EducationMapping() { 
            CreateMap<Education,EducationDto>().ReverseMap();
        }
    }
}
