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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetByID(int id)
        {
           return _aboutDal.GetByID(id);
        }

        public List<About> TGetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void TUpdate(About entity)
        {
           _aboutDal.Update(entity);
        }

        public List<About> TWhere(Expression<Func<About, bool>> expression)
        {
            return _aboutDal.Where(expression);
        }
    }
}
