using Domain.UserModule;

namespace Application.Contracts.Authentication;

public interface IJwtProvider
{
    /// <summary>
    /// Generates a JWT token for the given user
    /// </summary>
    /// <param name="user">The user to generate a JWT token for</param>
    /// <returns>JWT token string</returns>
    string Generate(User user);
    
    /// <summary>
    /// Generates a refresh token for the given user
    /// </summary>
    /// <returns>Refresh token string</returns>
    string GenerateRefreshToken();
}