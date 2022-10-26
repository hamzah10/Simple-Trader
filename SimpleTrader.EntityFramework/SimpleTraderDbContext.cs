using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContext :DbContext
    {
      

        public DbSet<User> Users { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public SimpleTraderDbContext(DbContextOptions options) : base(options) { }

        public SimpleTraderDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
