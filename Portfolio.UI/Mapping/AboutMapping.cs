using AutoMapper;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;


namespace Portfolio.API.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping() {
            CreateMap<About, AboutDto>().ReverseMap();
        }
    }
}
