namespace FVCommon.Services.Abstractions;

public interface ITokenService
{
    string GenerateAccessToken(int userId, string email, Role userRole);
}