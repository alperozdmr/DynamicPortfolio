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
    public class EducationManager : IEducationService
    {
        private readonly IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public void TAdd(Education entity)
        {
            _educationDal.Add(entity);
        }

        public void TDelete(Education entity)
        {
            _educationDal.Delete(entity);
        }

        public Education TGetByID(int id)
        {
            return _educationDal.GetByID(id);
        }

        public List<Education> TGetListAll()
        {
            return _educationDal.GetListAll();
        }

        public void TUpdate(Education entity)
        {
            _educationDal.Update(entity);
        }

        public List<Education> TWhere(Expression<Func<Education, bool>> expression)
        {
            return _educationDal.Where(expression);
        }
    }
}
