using Microsoft.AspNetCore.Mvc;
using Models.ResponsePayloads;

namespace Api.Controllers;

/// <summary>
/// Status API.
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/status")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class StatusController : ControllerBase
{
    private const string Api1Description = "API v1.0 without auth.";
    private const string Api2Description = "API v2.0 with auth.";

    /// <summary>
    /// Returns status of API v1.0.
    /// </summary>
    /// <returns><see cref="StatusResponsePayload"/></returns>
    [HttpGet]
    [MapToApiVersion("1.0")]
    public StatusResponsePayload GetApi1()
    {
        return new StatusResponsePayload
        {
            Version = 1,
            Description = Api1Description
        };
    }

    /// <summary>
    /// Returns status of API v2.0.
    /// </summary>
    /// <returns><see cref="StatusResponsePayload"/></returns>
    [HttpGet]
    [MapToApiVersion("2.0")]
    public StatusResponsePayload GetApi2()
    {
        return new StatusResponsePayload
        {
            Version = 2,
            Description = Api2Description
        };
    }
}
