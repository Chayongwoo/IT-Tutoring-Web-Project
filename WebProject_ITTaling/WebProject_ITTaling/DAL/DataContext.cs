using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebProject_ITTaling.Models;

namespace WebProject_ITTaling.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
            
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<License> Licenses { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<ApplySchedule> ApplySchedules { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }




    }
}