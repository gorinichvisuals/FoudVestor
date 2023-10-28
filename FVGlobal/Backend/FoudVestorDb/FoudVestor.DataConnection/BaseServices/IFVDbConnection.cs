namespace FoudVestor.DataConnection.BaseServices;

public interface IFVDbConnection
{
    ICategoryRepository CategoryRepository { get; }
    ICompanyRepository CompanyRepository { get; }
    ICountryRepository CountryRepository { get; }
    ICountryToCategoryRepository CountryToCategoryRepository { get; }
    ICountryToProjectRepository CountryToProjectRepository { get; }
    IFounderRepository FounderRepository { get; }
    IFounderSubscriptionRepository FounderSubscriptionRepository { get; }
    IInvestmentPortfolioRepository InvestmentPortfolioRepository { get; }
    IInvestorRepository InvestorRepository { get; }
    IInvestorAreaRepository InvestorAreaRepository { get; }
    IInvestorSubscriptionRepository InvestorSubscriptionRepository { get; }
    IPlatformSupportRepository PlatformSupportRepository { get; }
    IProjectRepository ProjectRepository { get; }
    IProjectToFounderRepository ProjectToFounderRepository { get; }

    Task SaveChanges();
}