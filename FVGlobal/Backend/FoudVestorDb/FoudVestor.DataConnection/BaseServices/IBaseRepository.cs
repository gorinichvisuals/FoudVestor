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

    public async Task<TResult?> GetOneItem<TResult>(
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var query = FoudVestorContext.Set<T>().AsNoTracking();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return await query.Select(select)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ICollection<TResult>> GetItemList<TResult>(
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, object>>? sortPredicate = null,
        int skipItems = default,
        int takeItems = default,
        bool ascending = true,
        CancellationToken cancellationToken = default)
    {
        var query = FoudVestorContext.Set<T>().AsNoTracking();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (sortPredicate is not null)
        {
            query = ascending
                ? query.OrderBy(sortPredicate)
                : query.OrderByDescending(sortPredicate);
        }

        if (takeItems != default)
        {
            query = query.Skip(skipItems).Take(takeItems);
        }

        return await query.Select(select).ToListAsync(cancellationToken);
    }

    public async Task<(ICollection<TResult>, int)> GetItemListWithCount<TResult>(
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, object>>? sortPredicate = null,
        int skipItems = default,
        int takeItems = default,
        bool ascending = true,
        CancellationToken cancellationToken = default)
    {
        var query = FoudVestorContext.Set<T>().AsNoTracking();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (sortPredicate is not null)
        {
            query = ascending
                ? query.OrderBy(sortPredicate)
                : query.OrderByDescending(sortPredicate);
        }

        var count = await query.CountAsync(cancellationToken);

        if (takeItems != default)
        {
            query = query.Skip(skipItems).Take(takeItems);
        }

        var items = await query.Select(select).ToListAsync(cancellationToken);

        return (items, count);
    }

    public async Task<int> GetCount(CancellationToken cancellationToken = default)
    {
        return await FoudVestorContext.Set<T>().CountAsync(cancellationToken);
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