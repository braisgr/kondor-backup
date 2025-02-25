using Kondor.Application.Common.Models;
using MediatR;

namespace Kondor.Application.Connections.Queries.GetConnections;

public record GetConnectionsQuery : IRequest<IEnumerable<ConnectionDto>>;