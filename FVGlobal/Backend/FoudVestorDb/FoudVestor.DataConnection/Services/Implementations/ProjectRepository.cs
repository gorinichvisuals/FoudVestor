namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class ProjectRepository : IProjectRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public ProjectRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}