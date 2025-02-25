using AutoMapper;
using Kondor.Application.Common.Models;
using Kondor.Domain.Repositories;
using MediatR;

namespace Kondor.Application.Connections.Queries.GetConnections;

public class GetConnectionsQueryHandler : IRequestHandler<GetConnectionsQuery, IEnumerable<ConnectionDto>>
{
    private readonly IConnectionRepository _connectionRepository;
    private readonly IMapper _mapper;

    public GetConnectionsQueryHandler(IConnectionRepository connectionRepository, IMapper mapper)
    {
        _connectionRepository = connectionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ConnectionDto>> Handle(GetConnectionsQuery request, CancellationToken cancellationToken)
    {
        var connections = await _connectionRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ConnectionDto>>(connections);
    }
}