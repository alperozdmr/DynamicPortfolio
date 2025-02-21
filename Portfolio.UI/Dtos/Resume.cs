using Portfolio.Entity.concrete;

namespace Portfolio.UI.Dtos
{
    public class Resume
    {
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
