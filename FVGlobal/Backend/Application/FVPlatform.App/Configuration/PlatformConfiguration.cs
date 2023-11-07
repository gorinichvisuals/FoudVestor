namespace FVPlatform.App.Configuration;

public static class PlatformConfiguration
{
    public static void PlatformConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IFounderService, FounderService>();
        services.AddScoped<IAuthorizeService, AuthorizeService>();
    }
}