namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class InvestorSubscriptionRepository : IInvestorSubscriptionRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public InvestorSubscriptionRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}