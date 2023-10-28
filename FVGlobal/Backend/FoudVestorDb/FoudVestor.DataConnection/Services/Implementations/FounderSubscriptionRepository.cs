namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class FounderSubscriptionRepository : IFounderSubscriptionRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public FounderSubscriptionRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}