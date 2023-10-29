namespace FVSupport.App.Configuration;

public static class SupportConfiguration
{
    public static void SupportConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}