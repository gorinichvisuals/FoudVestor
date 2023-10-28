namespace FVCommon.Configuration;

public static class CommonComfiguration
{
    public static void CommonConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }
}