namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class CategoryRepository : ICategoryRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public CategoryRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }

    public async Task UpdateCategory(Expression<Func<Category, bool>> predicate, string categoryName)
    {
        await FoudVestorContext.Categories
            .Where(predicate)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, categoryName));
    }
}