namespace FoudVestor.DataConnection.Services.Abstractions;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task UpdateCountry(Expression<Func<Country, bool>> predicate, 
        string name, string countryCode, string threeLettersISOCode);
}