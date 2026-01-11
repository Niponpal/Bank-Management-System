namespace BankManagementSystem.Models;

public class AccountCustomer
{
    public long Id { get; set; }

    // Account Info
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public bool IsActive { get; set; }
    // Customer Info
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string NID { get; set; }
    // Branch
    public long BranchId { get; set; }
    public Branch Branch { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
