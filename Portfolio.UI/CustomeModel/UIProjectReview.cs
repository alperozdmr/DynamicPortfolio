using Portfolio.Entity.concrete;

namespace Portfolio.UI.CustomeModel
{
    public class UIProjectReview
    {
        public string Category { get; set; }
        public string? Client { get; set; }
        public string ProjectUrl { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public List<ImageList> ImageLists { get; set; }
    }
}
