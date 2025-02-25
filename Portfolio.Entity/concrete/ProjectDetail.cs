using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.concrete
{
	public class ProjectDetail
	{
        public int ID { get; set; }
        public string Category { get; set; }
        public string? Client { get; set; }
        public string ProjectUrl { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public List<ImageList> ImageList { get; set; }
    }
}
