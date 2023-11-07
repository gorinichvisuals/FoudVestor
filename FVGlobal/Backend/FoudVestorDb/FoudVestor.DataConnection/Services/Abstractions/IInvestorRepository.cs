namespace FoudVestor.DataConnection.Services.Abstractions;

public interface IInvestorRepository : IBaseRepository<Investor>
{
    Task UpdateLastLogin(Expression<Func<Investor, bool>> predicateExpression);
}