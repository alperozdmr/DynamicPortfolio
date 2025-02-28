using AutoMapper;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;

namespace Portfolio.UI.Mapping
{
	public class ProjectDetailMapping : Profile
	{
		public ProjectDetailMapping() {
			CreateMap<ProjectDetail,ProjectDetailDto>().ReverseMap();
		}
	}
}
