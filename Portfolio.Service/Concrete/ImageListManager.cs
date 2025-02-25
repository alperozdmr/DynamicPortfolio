using Portfolio.DataAccess.Abstract;
using Portfolio.Entity.concrete;
using Portfolio.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Service.Concrete
{
	public class ImageListManager : IImageListService
	{
		private readonly IImageListDal _ımageListDal;

		public ImageListManager(IImageListDal ımageListDal)
		{
			_ımageListDal = ımageListDal;
		}

		public void TAdd(ImageList entity)
		{
			_ımageListDal.Add(entity);
		}

		public void TDelete(ImageList entity)
		{
			_ımageListDal.Delete(entity);
		}

		public ImageList TGetByID(int id)
		{
			return _ımageListDal.GetByID(id);
		}

		public List<ImageList> TGetListAll()
		{
			return _ımageListDal.GetListAll();
		}

		public void TUpdate(ImageList entity)
		{
			_ımageListDal.Update(entity);
		}

		public List<ImageList> TWhere(Expression<Func<ImageList, bool>> expression)
		{
			return _ımageListDal.Where(expression);
		}
	}
}
