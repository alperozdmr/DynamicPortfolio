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
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public void TAdd(Project entity)
        {
            _projectDal.Add(entity);
        }

        public void TDelete(Project entity)
        {
            _projectDal.Delete(entity);
        }

        public Project TGetByID(int id)
        {
            return _projectDal.GetByID(id);
        }

        public List<Project> TGetListAll()
        {
           return _projectDal.GetListAll();
        }

        public void TUpdate(Project entity)
        {
            _projectDal.Update(entity);
        }

        public List<Project> TWhere(Expression<Func<Project, bool>> expression)
        {
            return _projectDal.Where(expression);
        }
    }
}
