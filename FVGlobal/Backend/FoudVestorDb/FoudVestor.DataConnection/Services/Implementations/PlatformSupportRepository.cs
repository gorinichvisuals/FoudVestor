namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class PlatformSupportRepository : IPlatformSupportRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public PlatformSupportRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}