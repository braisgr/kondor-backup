using Kondor.Domain.Common;
using Kondor.Domain.Enums;
using Kondor.Domain.ValueObjects;

namespace Kondor.Domain.Entities;

public class DatabaseConnection
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DatabaseType Type { get; private set; }
    public ConnectionString ConnectionString { get; private set; }
    public string Host { get; private set; }
    public int Port { get; private set; }
    public string Database { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool IsEnabled { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastUsedAt { get; private set; }

    private DatabaseConnection() { } // Para EF Core

    public static Result<DatabaseConnection> Create(
        string name,
        DatabaseType type,
        string connectionString,
        string host,
        int port,
        string database,
        string username,
        string password)
    {
        var connStrResult = ConnectionString.Create(connectionString);
        if (!connStrResult.IsSuccess)
            return Result<DatabaseConnection>.Failure(connStrResult.Error);

        if (string.IsNullOrWhiteSpace(name))
            return Result<DatabaseConnection>.Failure("Name is required");

        if (port <= 0 || port > 65535)
            return Result<DatabaseConnection>.Failure("Invalid port number");

        return Result<DatabaseConnection>.Success(new DatabaseConnection
        {
            Id = Guid.NewGuid(),
            Name = name,
            Type = type,
            ConnectionString = connStrResult.Value,
            Host = host,
            Port = port,
            Database = database,
            Username = username,
            Password = password,
            IsEnabled = true,
            CreatedAt = DateTime.UtcNow
        });
    }

    public void UpdateLastUsed()
    {
        LastUsedAt = DateTime.UtcNow;
    }
    
}