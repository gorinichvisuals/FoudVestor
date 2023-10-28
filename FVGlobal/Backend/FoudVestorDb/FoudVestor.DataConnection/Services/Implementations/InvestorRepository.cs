namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class InvestorRepository : IInvestorRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public InvestorRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}