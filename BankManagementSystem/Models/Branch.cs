namespace BankManagementSystem.Models;

public class Branch
{
    public long Id { get; set; }
    public string BranchCode { get; set; }
    public string BranchName { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public ICollection<AccountCustomer> AccountCustomers { get; set; }

}
