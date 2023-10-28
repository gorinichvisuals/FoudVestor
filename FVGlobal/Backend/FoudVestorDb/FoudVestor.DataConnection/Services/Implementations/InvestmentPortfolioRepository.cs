namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class InvestmentPortfolioRepository : IInvestmentPortfolioRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public InvestmentPortfolioRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}