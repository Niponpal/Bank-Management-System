namespace BankManagementSystem.Models;

public class Transaction
{
    public long Id { get; set; }

    public long AccountCustomerId { get; set; }
    public AccountCustomer AccountCustomer { get; set; }

    public decimal Amount { get; set; }

    // 1 = Deposit, 2 = Withdrawal, 3 = Transfer
    public int TransactionType { get; set; }

    public string Reference { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
