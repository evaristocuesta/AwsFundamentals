﻿namespace Customers.Api.Contracts.Messages;

public class CustomerCreated
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string GitHubUserName { get; init; }
    public required DateTime DateOfBirh { get; init; }
}
