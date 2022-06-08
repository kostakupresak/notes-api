using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace Api.Controllers;

/// <summary>
/// Auth API.
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/auth")]
[ApiVersion("2.0")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Constructor for <see cref="AuthController"/>.
    /// </summary>
    /// <param name="userService"><see cref="IUserService"/>.</param>
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Performs login.
    /// </summary>
    /// <param name="userRequestPayload">
    /// <see cref="UserRequestPayload"/>.
    /// </param>
    /// <returns><see cref="TokenResponsePayload"/>.</returns>
    [HttpPost("login")]
    [MapToApiVersion("2.0")]
    public async Task<TokenResponsePayload> Login(
        [FromBody] UserRequestPayload userRequestPayload)
    {
        return await _userService.Validate(userRequestPayload);
    }

    /// <summary>
    /// Performs register.
    /// </summary>
    /// <param name="userRequestPayload">
    /// <see cref="UserRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    [HttpPost("register")]
    [MapToApiVersion("2.0")]
    public async Task Register(
        [FromBody] UserRequestPayload userRequestPayload)
    {
        await _userService.Add(userRequestPayload);
    }
}
