using Microsoft.EntityFrameworkCore;
using Portfolio.Entity.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Context
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMHHP22\\MSSQLSERVER01;Initial Catalog=PortfoliDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Education> Educations{ get; set; }
        public DbSet<Experience> Experiences{ get; set; }

    }
}
