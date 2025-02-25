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
	public class ProjectDetailManager : IProjectDetailService
	{
		private readonly IProjectDetailDal _projectDetailDal;

		public ProjectDetailManager(IProjectDetailDal projectDetailDal)
		{
			_projectDetailDal = projectDetailDal;
		}

		public void TAdd(ProjectDetail entity)
		{
			_projectDetailDal.Add(entity);
		}

		public void TDelete(ProjectDetail entity)
		{
			_projectDetailDal.Delete(entity);
		}

		public ProjectDetail TGetByID(int id)
		{
			return _projectDetailDal.GetByID(id);
		}

		public List<ProjectDetail> TGetListAll()
		{
			return _projectDetailDal.GetListAll();
		}

		public void TUpdate(ProjectDetail entity)
		{
			_projectDetailDal.Update(entity);
		}

		public List<ProjectDetail> TWhere(Expression<Func<ProjectDetail, bool>> expression)
		{
			return _projectDetailDal.Where(expression);
		}
	}
}
