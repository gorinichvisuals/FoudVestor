namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class FounderRepository : IFounderRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public FounderRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }

    public async Task UpdateLastLogin(Expression<Func<Founder, bool>> predicateExpression)
    {
        DateTime lastLogin = DateTime.UtcNow;

        await FoudVestorContext.Founders
            .Where(predicateExpression)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.LastLoginTime, lastLogin));
    }
}