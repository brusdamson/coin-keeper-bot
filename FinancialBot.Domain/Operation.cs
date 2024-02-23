namespace FinancialBot.Domain;

public class Operation
{
    public Guid Id { get; set; }
    
    public OperationType OperationType { get; set; }
    
    public DateTime Date { get; set; }
    
    public AppUser User { get; set; }
    
    public Guid UserId { get; set; }
    
    public Category Category { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public Purchase Purchase { get; set; }
    
    public Guid PurchaseId { get; set; }
}