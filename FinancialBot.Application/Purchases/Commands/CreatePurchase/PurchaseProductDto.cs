﻿namespace FinancialBot.Application.Purchases.Commands.CreatePurchase;

public class PurchaseProductDto
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}