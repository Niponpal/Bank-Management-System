using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<AccountCustomer> AccountCustomers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

}
