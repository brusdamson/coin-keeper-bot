﻿namespace FinancialBot.Domain;

public class Purchase
{
    public Guid Id { get; set; }

    public DateTime PurchaseDate { get; set; }

    public double TotalCost { get; set; }

    public List<PurchaseProduct> PurchaseProducts { get; } = [];

    public List<Product> Products { get; } = [];

    public List<Operation> Operations { get; } = [];
}