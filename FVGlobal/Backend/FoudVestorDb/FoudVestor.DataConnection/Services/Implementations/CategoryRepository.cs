namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class CategoryRepository : ICategoryRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public CategoryRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}