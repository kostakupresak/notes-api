using Models.Entities;

namespace Contracts.Repositories;

/// <summary>
/// Contract for category repository.
/// </summary>
public interface ICategoryRepository : ICrudRepository<Category>
{
}
