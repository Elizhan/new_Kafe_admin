using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AdminKafe.Models;
//using AdminKafe.Models;
namespace AdminKafe.Date
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ReceiptGoods> ReceiptGoods { get; set; }
        public DbSet<Reciep> Recipes { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Statuses> Status { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<CafeName> CafeName { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("server=192.168.0.108;user=kafe;password=1;database=BasaKafe;",
            //     new MySqlServerVersion(new Version(5, 7, 29))
            // );
            optionsBuilder.UseMySql("server=localhost;user=root;password=;database=BasaKafe;", new MySqlServerVersion(new Version(5, 7, 30)));
        }
    }
}
