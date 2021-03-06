﻿using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<HireRequest>()
             .HasOne(c => c.ThisClient)
             .WithMany()
             .HasForeignKey(u => u.ClientId);
            modelBuilder.Entity<HireRequest>()
             .HasOne(c => c.ThisContractor)
             .WithMany()
             .HasForeignKey(u => u.ContractorId);
            modelBuilder.Entity<HireRequest>().HasData(
              new HireRequest(1, "101", "100")
              {
                  HireRequestId = 1,
                  ContractorId = null,
                  ClientId = null,
                  RequestStatus = "Pending"


              }
             );

        }

    



        public DbSet<LoginInfo> LoginInfos { get; set; }
        public DbSet<Contractor> Contractors { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectPositions> ProjectPositions { get; set; }

        public DbSet <PositionNeedsSkill> PositionNeedsSkills { get; set; }

      //  public DbSet <UserHasSkill> UserHasSkills { get; set; }

        public DbSet <HireRequest> HireRequests { get; set; }
    }
}
