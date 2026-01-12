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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // ===============================
        // Branch → AccountCustomer (1 : M)
        // ===============================
        modelBuilder.Entity<AccountCustomer>()
            .HasOne(ac => ac.Branch)
            .WithMany(b => b.AccountCustomers)
            .HasForeignKey(ac => ac.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        // ===============================
        // AccountCustomer → Transaction (1 : M)
        // ===============================
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.AccountCustomer)
            .WithMany(ac => ac.Transactions)
            .HasForeignKey(t => t.AccountCustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
