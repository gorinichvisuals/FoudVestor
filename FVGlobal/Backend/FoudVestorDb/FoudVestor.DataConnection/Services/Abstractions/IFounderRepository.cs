namespace FoudVestor.DataConnection.Services.Abstractions;

public interface IFounderRepository : IBaseRepository<Founder>
{
    Task UpdateLastLogin(Expression<Func<Founder, bool>> predicateExpression);
}