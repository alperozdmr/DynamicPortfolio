﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Helper.Dtos
{
	public class ImageListDto
	{
		public int ID { get; set; }
		public string ImageUrl { get; set; }
		public int ProjectId { get; set; }
	}
}
