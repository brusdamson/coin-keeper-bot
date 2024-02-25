namespace FinancialBot.Application.Telegram.Interfaces;

public interface IQrReader
{ 
    Task<string> ScanAsync(Stream imageStream);
    
    string Scan(Stream imageStream);
}