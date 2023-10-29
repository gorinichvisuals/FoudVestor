namespace FoudVestor.DataConnection.Services.Abstractions;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task UpdateCategory(Expression<Func<Category, bool>> predicate, string categoryName);
}