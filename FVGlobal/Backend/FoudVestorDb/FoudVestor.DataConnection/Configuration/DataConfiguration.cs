namespace FoudVestor.DataConnection.Configuration;

public static class DataConfiguration
{
    public static void DataConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IFVDbConnection, FVDbConnection>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICountryToCategoryRepository, CountryToCategoryRepository>();
        services.AddScoped<ICountryToProjectRepository, CountryToProjectRepository>();
        services.AddScoped<IFounderRepository, FounderRepository>();
        services.AddScoped<IFounderSubscriptionRepository, FounderSubscriptionRepository>();
        services.AddScoped<IInvestmentPortfolioRepository, InvestmentPortfolioRepository>();
        services.AddScoped<IInvestorAreaRepository, InvestorAreaRepository>();
        services.AddScoped<IInvestorRepository, InvestorRepository>();
        services.AddScoped<IInvestorSubscriptionRepository, InvestorSubscriptionRepository>();
        services.AddScoped<IPlatformSupportRepository, PlatformSupportRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectToFounderRepository, ProjectToFounderRepository>();
    }
}