namespace Customers.Consumer.Contracts.Messages;

public class CustomerDeleted : ISqsMessage
{
    public required Guid Id { get; init; }
}
