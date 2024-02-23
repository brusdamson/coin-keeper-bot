namespace FinancialBot.Domain;

public class Product
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public double Price { get; set; }

    public List<PurchaseProduct> PurchaseProducts { get; } = [];

    public List<Purchase> Purchases { get; } = [];
}