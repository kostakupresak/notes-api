using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace Contracts.Services;

/// <summary>
/// Contract for category service.
/// </summary>
public interface ICategoryService
    : ICrudService<CategoryRequestPayload, CategoryResponsePayload>
{
}
