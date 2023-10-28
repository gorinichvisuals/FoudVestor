namespace FoudVestor.DataConnection.BaseServices;

public interface IBaseRepository<T> where T : class
{
    protected internal FoudVestorContext FoudVestorContext { get; }

    public async Task Create(T entity)
    {
        await FoudVestorContext.Set<T>().AddAsync(entity);
    }

    public async Task CreateRange(ICollection<T> entities)
    {
        await FoudVestorContext.Set<T>().AddRangeAsync(entities);
    }

    public async Task Delete(Expression<Func<T, bool>> predicate)
    {
        await FoudVestorContext.Set<T>().Where(predicate).ExecuteDeleteAsync();
    }

    public async Task<T?> GetFirstOrDefault(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await FoudVestorContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TResult?> GetFirstOrDefaultSelect<TResult>(
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var query = FoudVestorContext.Set<T>().AsNoTracking();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.Select(select)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ICollection<TResult>> GetListWithSelect<TResult>(
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, object>>? sortPredicate = null,
        int page = default,
        int pageSize = default,
        bool ascending = true,
        CancellationToken cancellationToken = default)
    {
        var query = FoudVestorContext.Set<T>().AsNoTracking();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (sortPredicate != null)
        {
            query = ascending
                ? query.OrderBy(sortPredicate)
                : query.OrderByDescending(sortPredicate);
        }

        if (page != default && pageSize != default)
        {
            query = query.Skip(page * pageSize).Take(pageSize);
        }

        return await query.Select(select).ToListAsync(cancellationToken);
    }

    public async Task<ICollection<T>> GetListWithoutSelect(
        Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, object>>? sortPredicate = null,
        int page = default,
        int pageSize = default,
        bool ascending = true,
        CancellationToken cancellationToken = default)
    {
        var query = FoudVestorContext.Set<T>().AsNoTracking();

        if(predicate != null)
        {
            query = query.Where(predicate);
        }

        if (sortPredicate != null)
        {
            query = ascending
                ? query.OrderBy(sortPredicate)
                : query.OrderByDescending(sortPredicate);
        }

        if (page != default && pageSize != default)
        {
            query = query.Skip(page * pageSize).Take(pageSize);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> GetCount(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await FoudVestorContext.Set<T>().CountAsync(predicate, cancellationToken);
    }

    public async Task<bool> Any(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await FoudVestorContext.Set<T>().AnyAsync(predicate, cancellationToken);
    }
}