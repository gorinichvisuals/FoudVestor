namespace FoudVestor.DataConnection.BaseServices;

internal sealed class FVDbConnection : IFVDbConnection
{
    private readonly FoudVestorContext data;
    public ICategoryRepository CategoryRepository { get; set; }
    public ICompanyRepository CompanyRepository { get; set; } 
    public ICountryRepository CountryRepository { get; set; }
    public ICountryToCategoryRepository CountryToCategoryRepository { get; set; }
    public ICountryToProjectRepository CountryToProjectRepository { get; set; }
    public IFounderRepository FounderRepository { get; set; }
    public IFounderSubscriptionRepository FounderSubscriptionRepository { get; set; }
    public IInvestmentPortfolioRepository InvestmentPortfolioRepository { get; set; }
    public IInvestorRepository InvestorRepository { get; set; }
    public IInvestorAreaRepository InvestorAreaRepository { get; set; }
    public IInvestorSubscriptionRepository InvestorSubscriptionRepository { get; set; }
    public IPlatformSupportRepository PlatformSupportRepository { get; set; }
    public IProjectRepository ProjectRepository { get; set; }
    public IProjectToFounderRepository ProjectToFounderRepository { get; set; }

    public FVDbConnection(
        FoudVestorContext data,
        ICategoryRepository categoryRepository,
        ICompanyRepository companyRepository,
        ICountryRepository countryRepository,
        ICountryToCategoryRepository countryToCategoryRepository,
        ICountryToProjectRepository countryToProjectRepository,
        IFounderRepository founderRepository,
        IFounderSubscriptionRepository founderSubscriptionRepository,
        IInvestmentPortfolioRepository investmentPortfolioRepository,
        IInvestorRepository investorRepository,
        IInvestorAreaRepository investorAreaRepository,
        IInvestorSubscriptionRepository investorSubscriptionRepository,
        IPlatformSupportRepository platformSupportRepository,
        IProjectRepository projectRepository,
        IProjectToFounderRepository projectToFounderRepository)
    {
        this.data = data;
        CategoryRepository = categoryRepository;
        CompanyRepository = companyRepository;
        CountryRepository = countryRepository;
        CountryToCategoryRepository = countryToCategoryRepository;
        CountryToProjectRepository = countryToProjectRepository;
        FounderRepository = founderRepository;
        FounderSubscriptionRepository = founderSubscriptionRepository;
        InvestmentPortfolioRepository = investmentPortfolioRepository;
        InvestorRepository = investorRepository;
        InvestorAreaRepository = investorAreaRepository;
        InvestorSubscriptionRepository = investorSubscriptionRepository;
        PlatformSupportRepository = platformSupportRepository;
        ProjectRepository = projectRepository;
        ProjectToFounderRepository = projectToFounderRepository;
    }

    public async Task SaveChanges() => await data.SaveChangesAsync();
}