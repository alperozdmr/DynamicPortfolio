using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.concrete
{
	public class ImageList
	{
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public int ProjectDetailID { get; set; }
        public ProjectDetail ProjectDetail { get; set; }
    }
}
