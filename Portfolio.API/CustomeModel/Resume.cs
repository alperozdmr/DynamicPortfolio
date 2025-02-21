using Portfolio.Entity.concrete;

namespace Portfolio.API.CustomeModel
{
    public class Resume
    {
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
