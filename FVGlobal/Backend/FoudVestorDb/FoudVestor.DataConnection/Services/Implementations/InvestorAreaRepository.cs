namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class InvestorAreaRepository : IInvestorAreaRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public InvestorAreaRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}