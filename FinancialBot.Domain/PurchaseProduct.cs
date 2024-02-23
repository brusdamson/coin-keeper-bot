namespace FinancialBot.Domain;

public class PurchaseProduct
{
    public Guid Id { get; set; }

    public Guid PurchaseId { get; set; }

    public Purchase Purchase { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; }
}