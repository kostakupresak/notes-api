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
    private const string api1Description = "API v1.0 without auth.";
    private const string api2Description = "API v2.0 with auth.";

    /// <summary>
    /// Returns status of API v1.0.
    /// </summary>
    /// <returns><see cref="StatusPayload"/></returns>
    [HttpGet]
    [MapToApiVersion("1.0")]
    public StatusPayload GetApi1()
    {
        return new StatusPayload
        {
            Version = 1,
            Description = api1Description
        };
    }

    /// <summary>
    /// Returns statu of API v2.0.
    /// </summary>
    /// <returns><see cref="StatusPayload"/></returns>
    [HttpGet]
    [MapToApiVersion("2.0")]
    public StatusPayload GetApi2()
    {
        return new StatusPayload
        {
            Version = 2,
            Description = api2Description
        };
    }
}
