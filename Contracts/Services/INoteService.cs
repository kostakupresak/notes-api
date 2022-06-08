using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace Contracts.Services;

/// <summary>
/// Contract for note service.
/// </summary>
public interface INoteService
    : ICrudService<NoteRequestPayload, NoteResponsePayload>
{
}
