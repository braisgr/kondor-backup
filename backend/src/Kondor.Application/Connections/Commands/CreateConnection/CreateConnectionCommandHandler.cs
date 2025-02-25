using Kondor.Domain.Common;
using Kondor.Domain.Entities;
using Kondor.Domain.Repositories;
using MediatR;

namespace Kondor.Application.Connections.Commands.CreateConnection;

public class CreateConnectionCommandHandler : IRequestHandler<CreateConnectionCommand, Result<Guid>>
{
    private readonly IConnectionRepository _connectionRepository;

    public CreateConnectionCommandHandler(IConnectionRepository connectionRepository)
    {
        _connectionRepository = connectionRepository;
    }

    public async Task<Result<Guid>> Handle(CreateConnectionCommand request, CancellationToken cancellationToken)
    {
        // Crear la entidad de dominio
        var connectionResult = DatabaseConnection.Create(
            request.Name,
            request.Type,
            request.ConnectionString,
            request.Host,
            request.Port,
            request.Database,
            request.Username,
            request.Password);

        if (!connectionResult.IsSuccess)
            return Result<Guid>.Failure(connectionResult.Error);

        // Guardar en el repositorio
        var connection = await _connectionRepository.AddAsync(connectionResult.Value, cancellationToken);
        
        return Result<Guid>.Success(connection.Id);
    }
}