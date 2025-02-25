using Kondor.Domain.Common;
using Kondor.Domain.Enums;
using MediatR;

namespace Kondor.Application.Connections.Commands.CreateConnection;

public record CreateConnectionCommand : IRequest<Result<Guid>>
{
    public string Name { get; init; }
    public DatabaseType Type { get; init; }
    public string Host { get; init; }
    public int Port { get; init; }
    public string Database { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string ConnectionString { get; init; }
}