namespace FinancialBot.Application.Common.Exceptions;

public class EntityNotFoundException(string name, object key)
    : Exception($"Entity {name} with key: ({key}) not found.");