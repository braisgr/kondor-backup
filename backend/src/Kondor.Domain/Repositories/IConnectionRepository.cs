using Kondor.Domain.Common;
using Kondor.Domain.Entities;

namespace Kondor.Domain.Repositories;

public interface IConnectionRepository
{
    Task<Result<DatabaseConnection>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<DatabaseConnection>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<DatabaseConnection> AddAsync(DatabaseConnection connection, CancellationToken cancellationToken = default);
    Task UpdateAsync(DatabaseConnection connection, CancellationToken cancellationToken = default);
    Task<Result<bool>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}