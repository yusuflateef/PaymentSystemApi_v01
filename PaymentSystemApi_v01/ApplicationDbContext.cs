using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentSystemApi_v01.Core;

namespace PaymentSystemApi_v01
{
    public class ApplicationDbContext:DbContext
    {
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Marchant> Marchants { get; set; }
        public DbSet<TransactionHistory> transactionHistories { get; set; }

    }
}
