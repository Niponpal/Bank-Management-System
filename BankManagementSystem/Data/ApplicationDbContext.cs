using BankManagementSystem.Auth_IdentityModel;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace BankManagementSystem.Data;

public class ApplicationDbContext : IdentityDbContext<
    IdentityModel.User,
    IdentityModel.Role,
    long,
    IdentityModel.UserClaim,
    IdentityModel.UserRole,
    IdentityModel.UserLogin,
    IdentityModel.RoleClaim,
    IdentityModel.UserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
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

        base.OnModelCreating(modelBuilder);
        // Automatically apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() }));
    }



}
