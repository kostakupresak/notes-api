using Contracts.Repositories;
using Contracts.Services;
using Models.Entities;
using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace BusinessLogic;

/// <summary>
/// Note service.
/// </summary>
public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    /// <summary>
    /// Constructor for <see cref="NoteService"/>.
    /// </summary>
    /// <param name="noteRepository">
    /// <see cref="INoteRepository"/>.
    /// </param>
    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    /// <inheritdoc cref="INoteService"/>
    public async Task<IEnumerable<NoteResponsePayload>> GetAll()
    {
        var notes = await _noteRepository.GetAll();

        return notes.Select(note => new NoteResponsePayload
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            LastUpdated = note.LastUpdated,
            Category = new CategoryResponsePayload
            {
                Id = note.Category.Id,
                Title = note.Category.Title
            }
        });
    }

    /// <inheritdoc cref="INoteService"/>
    public async Task<NoteResponsePayload> GetById(int id)
    {
        var note = await _noteRepository.GetById(id);

        return new NoteResponsePayload
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            LastUpdated = note.LastUpdated,
            Category = new CategoryResponsePayload
            {
                Id = note.Category.Id,
                Title = note.Category.Title
            }
        };
    }

    /// <inheritdoc cref="INoteService"/>
    public async Task Add(NoteRequestPayload requestPayload)
    {
        var note = new Note
        {
            Title = requestPayload.Title,
            Content = requestPayload.Content,
            Category = new Category
            {
                Id = requestPayload.CategoryId,
                Title = string.Empty
            }
        };

        await _noteRepository.Add(note);
    }

    /// <inheritdoc cref="INoteService"/>
    public async Task Update(
        int id,
        NoteRequestPayload requestPayload)
    {
        var note = new Note
        {
            Id = id,
            Title = requestPayload.Title,
            Content = requestPayload.Content,
            Category = new Category
            {
                Id = requestPayload.CategoryId,
                Title = string.Empty
            }
        };

        await _noteRepository.Update(note);
    }

    /// <inheritdoc cref="INoteService"/>
    public async Task Delete(int id)
    {
        await _noteRepository.Delete(id);
    }
}
