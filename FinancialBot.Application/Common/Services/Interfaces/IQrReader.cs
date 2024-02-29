namespace FinancialBot.Application.Common.Services.Interfaces;

public interface IQrReader
{
    Task<string> ScanAsync(Stream imageStream);

    string Scan(Stream imageStream);
}