using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOA.Model;
using HN.Model;
using Model;

namespace IOA.Common.Context
{
   public  class OnContext:DbContext
    {
        public static string connStr = ConfigurationHepler.configurations;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connStr");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<UsersInfo> UsersInfo { get; set; }


    }
}
