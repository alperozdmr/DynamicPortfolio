using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entity.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Context
{
    public class PortfolioContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMHHP22\\MSSQLSERVER01;Initial Catalog=PortfoliDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //    }
        //}
        public DbSet<About> Abouts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Education> Educations{ get; set; }
        public DbSet<Experience> Experiences{ get; set; }
        public DbSet<ProjectDetail> ProjectDetails{ get; set; }
        public DbSet<ImageList> ImageLists{ get; set; }

    }
}
