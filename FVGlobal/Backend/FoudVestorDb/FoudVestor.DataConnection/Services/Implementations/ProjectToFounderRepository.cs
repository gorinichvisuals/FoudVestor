namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class ProjectToFounderRepository : IProjectToFounderRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public ProjectToFounderRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}