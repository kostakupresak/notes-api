using Contracts.Repositories;
using Contracts.Services;
using Models.Entities;
using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace BusinessLogic;

/// <summary>
/// Category service.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Constructor for <see cref="CategoryService"/>.
    /// </summary>
    /// <param name="categoryRepository">
    /// <see cref="ICategoryRepository"/>.
    /// </param>
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <inheritdoc cref="ICategoryService"/>
    public async Task<IEnumerable<CategoryResponsePayload>> GetAll()
    {
        var categories = await _categoryRepository.GetAll();

        return categories.Select(category => new CategoryResponsePayload
        {
            Id = category.Id,
            Title = category.Title
        });
    }

    /// <inheritdoc cref="ICategoryService"/>
    public async Task<CategoryResponsePayload> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);

        return new CategoryResponsePayload
        {
            Id = category.Id,
            Title = category.Title
        };
    }

    /// <inheritdoc cref="ICategoryService"/>
    public async Task Add(CategoryRequestPayload requestPayload)
    {
        var category = new Category { Title = requestPayload.Title };

        await _categoryRepository.Add(category);
    }

    /// <inheritdoc cref="ICategoryService"/>
    public async Task Update(
        int id,
        CategoryRequestPayload requestPayload)
    {
        var category = new Category
        {
            Id = id,
            Title = requestPayload.Title
        };

        await _categoryRepository.Update(category);
    }

    /// <inheritdoc cref="ICategoryService"/>
    public async Task Delete(int id)
    {
        await _categoryRepository.Delete(id);
    }
}
