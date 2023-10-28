namespace FVCommon.Services.Implementations;

public sealed class TokenService : ITokenService
{
    private readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string GenerateAccessToken(int userId, string email, Role userRole)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtFVPlatform:Secret"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(FVPlatformClaimConstants.Role, userRole.ToString()),
            new Claim(FVPlatformClaimConstants.Id, userId!.ToString()!),
            new Claim(FVPlatformClaimConstants.Email, email)
        };

        var token = new JwtSecurityToken(
            configuration["JwtFVPlatform:Issuer"], 
            configuration["JwtFVPlatform:Audience"], 
            claims,
            expires: DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtFVPlatform:TokenExpires"])), 
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}