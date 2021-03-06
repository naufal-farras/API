using API.Models;
using API.ViewModel;
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
        public DbSet<Role> Role{ get; set; }
        public DbSet<AccountRole> AccountRole { get; set; }

        public DbSet<RegisterVM> RegisterVM { get; set; }


        //Account
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountRole>()
            .HasKey(ar => new { ar.NIK, ar.RoleId });

            modelBuilder.Entity<AccountRole>()
           .HasOne(a => a.Account)
           .WithMany(b => b.AccountRole)
           .HasForeignKey(a => a.NIK);

            modelBuilder.Entity<AccountRole>()
           .HasOne(a => a.Role)
           .WithMany(b => b.AccountRole)
           .HasForeignKey(a => a.RoleId);

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


            modelBuilder.Entity<RegisterVM>().HasNoKey();
        }
    }

}
