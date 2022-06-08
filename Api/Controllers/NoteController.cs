using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace Api.Controllers;

/// <summary>
/// Note API.
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/notes")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class NoteController : ControllerBase
{
    public readonly INoteService _noteService;

    /// <summary>
    /// Constructor for <see cref="NoteController"/>.
    /// </summary>
    /// <param name="noteService"><see cref="INoteService"/>.</param>
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    /// <summary>
    /// Gets all notes.
    /// </summary>
    /// <returns>
    /// <see cref="Task{IEnumerable{NoteResponsePayload}}"/>.
    /// </returns>
    [HttpGet]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    public async Task<IEnumerable<NoteResponsePayload>> GetAllApi1()
    {
        return await _noteService.GetAll();
    }

    /// <summary>
    /// Gets note by id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="Task{NoteResponsePayload}"/>.</returns>
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    public async Task<NoteResponsePayload> GetByIdApi1([FromRoute] int id)
    {
        return await _noteService.GetById(id);
    }

    /// <summary>
    /// Adds a new note.
    /// </summary>
    /// <param name="noteRequestPayload">
    /// <see cref="NoteRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpPost]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    public async Task AddApi1(
        [FromBody] NoteRequestPayload noteRequestPayload)
    {
        await _noteService.Add(noteRequestPayload);
    }

    /// <summary>
    /// Updates a note.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="noteRequestPayload">
    /// <see cref="NoteRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    public async Task UpdateApi1(
        [FromRoute] int id,
        [FromBody] NoteRequestPayload noteRequestPayload)
    {
        await _noteService.Update(id, noteRequestPayload);
    }

    /// <summary>
    /// Deletes a note.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    public async Task DeleteApi1([FromRoute] int id)
    {
        await _noteService.Delete(id);
    }
}
