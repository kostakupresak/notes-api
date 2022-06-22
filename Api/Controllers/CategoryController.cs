using Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace Api.Controllers;

/// <summary>
/// Category API.
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/categories")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Constructor for <see cref="CategoryController"/>.
    /// </summary>
    /// <param name="categoryService"><see cref="ICategoryService"/>.</param>
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <returns>
    /// <see cref="IEnumerable{CategoryResponsePayload}"/>.
    /// </returns>
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IEnumerable<CategoryResponsePayload>> GetAllApi1()
    {
        return await _categoryService.GetAll();
    }

    /// <summary>
    /// Gets all categories.
    /// </summary>
    /// <returns>
    /// <see cref="IEnumerable{CategoryResponsePayload}"/>.
    /// </returns>
    [HttpGet, Authorize]
    [MapToApiVersion("2.0")]
    public async Task<IEnumerable<CategoryResponsePayload>> GetAllApi2()
    {
        return await _categoryService.GetAll();
    }

    /// <summary>
    /// Gets category by id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="CategoryResponsePayload"/>.</returns>
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    public async Task<CategoryResponsePayload> GetByIdApi1([FromRoute] int id)
    {
        return await _categoryService.GetById(id);
    }

    /// <summary>
    /// Gets category by id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="CategoryResponsePayload"/>.</returns>
    [HttpGet("{id}"), Authorize]
    [MapToApiVersion("2.0")]
    public async Task<CategoryResponsePayload> GetByIdApi2([FromRoute] int id)
    {
        return await _categoryService.GetById(id);
    }

    /// <summary>
    /// Adds a new category.
    /// </summary>
    /// <param name="categoryRequestPayload">
    /// <see cref="CategoryRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task AddApi1(
        [FromBody] CategoryRequestPayload categoryRequestPayload)
    {
        await _categoryService.Add(categoryRequestPayload);
    }

    /// <summary>
    /// Adds a new category.
    /// </summary>
    /// <param name="categoryRequestPayload">
    /// <see cref="CategoryRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpPost]
    [MapToApiVersion("2.0"), Authorize]
    public async Task AddApi2(
        [FromBody] CategoryRequestPayload categoryRequestPayload)
    {
        await _categoryService.Add(categoryRequestPayload);
    }

    /// <summary>
    /// Updates a category.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="categoryRequestPayload">
    /// <see cref="CategoryRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    public async Task UpdateApi1(
        [FromRoute] int id,
        [FromBody] CategoryRequestPayload categoryRequestPayload)
    {
        await _categoryService.Update(id, categoryRequestPayload);
    }

    /// <summary>
    /// Updates a category.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="categoryRequestPayload">
    /// <see cref="CategoryRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpPut("{id}")]
    [MapToApiVersion("2.0"), Authorize]
    public async Task UpdateApi2(
        [FromRoute] int id,
        [FromBody] CategoryRequestPayload categoryRequestPayload)
    {
        await _categoryService.Update(id, categoryRequestPayload);
    }

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    public async Task DeleteApi1([FromRoute] int id)
    {
        await _categoryService.Delete(id);
    }

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpDelete("{id}"), Authorize]
    [MapToApiVersion("2.0")]
    public async Task DeleteApi2([FromRoute] int id)
    {
        await _categoryService.Delete(id);
    }
}
