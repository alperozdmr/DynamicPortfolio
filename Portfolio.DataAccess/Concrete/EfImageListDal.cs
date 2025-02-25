using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Context;
using Portfolio.DataAccess.Repository;
using Portfolio.Entity.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Concrete
{
	public class EfImageListDal : GenericRepository<ImageList>, IImageListDal
	{
		public EfImageListDal(PortfolioContext context) : base(context)
		{
		}
	}
}
