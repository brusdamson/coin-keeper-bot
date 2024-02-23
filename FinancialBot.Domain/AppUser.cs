using System.Text.Json.Serialization;

namespace FinancialBot.Domain;

public class AppUser
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public long ChatId { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<Operation> Operations { get; } = [];
}