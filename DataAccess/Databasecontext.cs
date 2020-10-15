using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess.DataAccess
{
    public class Databasecontext : IdentityDbContext
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
            base.OnModelCreating(modelBuilder);
        }
    



        public DbSet<LoginInfo> LoginInfos { get; set; }
        public DbSet<Contractor> Contractors { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Skill> Skills { get; set; }

    }
}
