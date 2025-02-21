using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.concrete
{
    public class Education
    {
        public int ID { get; set; }
        public string Degree { get; set; } = " ";
        public string University { get; set; }
        public string Year { get; set; }
        public string Description { get; set; } = " ";
    }

}
