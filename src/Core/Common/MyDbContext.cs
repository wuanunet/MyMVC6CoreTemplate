using Microsoft.Data.Entity;
using MyMVC6Template.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6Template.Core.Common
{
    //http://ef.readthedocs.org/en/latest/getting-started/aspnet5/new-db.html
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conncectionString = AppHelper.Configuration["Data:ConnectionString"];
            optionsBuilder.UseSqlServer(conncectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Person> Persons { get; set; }

    }
}
