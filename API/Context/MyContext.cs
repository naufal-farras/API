using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        //set model
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Profiling> Profiling { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<University> University { get; set; }

        //Account
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //person to account
            modelBuilder.Entity<Person>()
           .HasOne(a => a.Account)
           .WithOne(b => b.Person)
           .HasForeignKey<Account>(b => b.NIK);

            //account to profiling
            modelBuilder.Entity<Account>()
           .HasOne(a => a.Profiling)
           .WithOne(b => b.Account)
           .HasForeignKey<Profiling>(b => b.NIK);

            //Education to Profiling
            modelBuilder.Entity<Education>()
           .HasMany(a => a.Profiling)
           .WithOne(b => b.Education);

            //uiniversity to education
            modelBuilder.Entity<University>()
           .HasMany(a => a.Education)
           .WithOne(b => b.University);

        }
    }

}
