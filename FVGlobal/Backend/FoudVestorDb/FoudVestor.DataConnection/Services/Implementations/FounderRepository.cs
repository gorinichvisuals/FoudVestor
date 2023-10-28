namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class FounderRepository : IFounderRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public FounderRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}