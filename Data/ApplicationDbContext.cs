﻿using LibApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MembershipType>().Property(x => x.Id).UseIdentityColumn();
            builder.Entity<Genre>().Property(x => x.Id).UseIdentityColumn();

            base.OnModelCreating(builder);
        }
    }
}
