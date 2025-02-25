using Kondor.Domain.Common;
using Kondor.Domain.Entities;
using Kondor.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kondor.Infrastructure.Persistence.Repositories;

public class ConnectionRepository : IConnectionRepository
{
    private readonly KondorDbContext _context;

    public ConnectionRepository(KondorDbContext context)
    {
        _context = context;
    }

    public async Task<Result<DatabaseConnection>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var connection = await _context.Connections
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return connection is null 
            ? Result<DatabaseConnection>.Failure($"Connection with id {id} not found")
            : Result<DatabaseConnection>.Success(connection);
    }

    public async Task<IEnumerable<DatabaseConnection>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Connections
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<DatabaseConnection> AddAsync(DatabaseConnection connection, CancellationToken cancellationToken = default)
    {
        await _context.Connections.AddAsync(connection, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return connection;
    }

    public async Task UpdateAsync(DatabaseConnection connection, CancellationToken cancellationToken = default)
    {
        _context.Entry(connection).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var connectionResult = await GetByIdAsync(id, cancellationToken);
        
        if (!connectionResult.IsSuccess)
            return Result<bool>.Failure(connectionResult.Error);

        _context.Connections.Remove(connectionResult.Value);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Result<bool>.Success(true);
    }
}