using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccess
{
    public class Databasecontext : DbContext
    {
        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginInfo>().HasData(
                  new LoginInfo
                  {

                      LoginInfoId = 1,
                      Username = "test",
                      Password = "test"



                  }
                  );
        }
    


        public DbSet<LoginInfo> LoginInfos{ get; set; }


    }
}
