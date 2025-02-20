using Microsoft.EntityFrameworkCore;
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
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(PortfolioContext context) : base(context)
        {
        }
    }
}
