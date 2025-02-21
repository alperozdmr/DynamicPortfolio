﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.concrete
{
    public class Experience
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Duration { get; set; }
        public string Responsibilities { get; set; } = " ";
    }
}
