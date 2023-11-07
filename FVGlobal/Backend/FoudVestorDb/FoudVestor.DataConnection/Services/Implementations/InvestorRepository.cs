namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class InvestorRepository : IInvestorRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public InvestorRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }

    public async Task UpdateLastLogin(Expression<Func<Investor, bool>> predicateExpression)
    {
        DateTime lastLogin = DateTime.UtcNow;

        await FoudVestorContext.Investors
            .Where(predicateExpression)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.LastLoginTime, lastLogin));
    }
}