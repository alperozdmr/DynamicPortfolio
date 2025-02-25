using AutoMapper;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;

namespace Portfolio.API.Mapping
{
	public class ProjectMapping : Profile
    {
        public ProjectMapping() {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
