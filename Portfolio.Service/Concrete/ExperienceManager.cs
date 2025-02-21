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
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public void TAdd(Experience entity)
        {
            _experienceDal.Add(entity);
        }

        public void TDelete(Experience entity)
        {
            _experienceDal.Delete(entity);
        }

        public Experience TGetByID(int id)
        {
            return _experienceDal.GetByID(id);
        }

        public List<Experience> TGetListAll()
        {
           return _experienceDal.GetListAll();
        }

        public void TUpdate(Experience entity)
        {
            _experienceDal.Update(entity);
        }

        public List<Experience> TWhere(Expression<Func<Experience, bool>> expression)
        {
            return _experienceDal.Where(expression);
        }
    }
}
