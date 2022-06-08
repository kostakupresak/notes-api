using Models.Entities;

namespace Contracts.Repositories;

/// <summary>
/// Contract for note repository.
/// </summary>
public interface INoteRepository : ICrudRepository<Note>
{
}
