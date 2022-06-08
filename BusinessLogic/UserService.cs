using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Contracts.Repositories;
using Contracts.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Models.Exceptions;
using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace BusinessLogic;

/// <summary>
/// User service.
/// </summary>
public class UserService : IUserService
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Constructor for <see cref="UserService"/>.
    /// </summary>
    /// <param name="configuration"><see cref="IConfiguration"/>.</param>
    /// <param name="userRepository"><see cref="IUserRepository"/>.</param>
    public UserService(
        IConfiguration configuration,
        IUserRepository userRepository)
    {
        _secretKey = configuration.GetValue<string>("SecretKey");
        _issuer = configuration.GetValue<string>("TokenIssuer");
        _audience = configuration.GetValue<string>("TokenAudience");

        _userRepository = userRepository;
    }

    /// <inheritdoc cref="IUserService"/>
    public async Task<TokenResponsePayload> Validate(
        UserRequestPayload userRequestPayload)
    {
        var user = new User
        {
            Username = userRequestPayload.Username,
            Password = userRequestPayload.Password
        };
        var hashedPassword = await _userRepository.Validate(user);

        if (hashedPassword is null)
        {
            throw new UnauthenticatedException();
        }

        if (!BCrypt.Net.BCrypt.Verify(
            userRequestPayload.Password,
            hashedPassword))
        {
            throw new UnauthenticatedException();
        }

        var secretKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var signinCredentials =
            new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokeOptions = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: new List<Claim>(),
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signinCredentials
        );

        return new TokenResponsePayload
        {
            Token = new JwtSecurityTokenHandler().WriteToken(tokeOptions)
        };
    }

    /// <inheritdoc cref="IUserService"/>
    public async Task Add(UserRequestPayload userRequestPayload)
    {
        var hashedPassword =
            BCrypt.Net.BCrypt.HashPassword(userRequestPayload.Password);

        var user = new User
        {
            Username = userRequestPayload.Username,
            Password = hashedPassword
        };

        await _userRepository.Add(user);
    }
}
