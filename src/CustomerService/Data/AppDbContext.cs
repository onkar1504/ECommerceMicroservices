using CustomerService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}