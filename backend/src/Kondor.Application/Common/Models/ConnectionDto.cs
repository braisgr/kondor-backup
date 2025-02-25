namespace Kondor.Application.Common.Models;

public class ConnectionDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Type { get; init; }
    public string Host { get; init; }
    public int Port { get; init; }
    public string Database { get; init; }
    public string Username { get; init; }
    public string ConnectionString { get; init; }
    public bool IsEnabled { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? LastUsedAt { get; init; }
}