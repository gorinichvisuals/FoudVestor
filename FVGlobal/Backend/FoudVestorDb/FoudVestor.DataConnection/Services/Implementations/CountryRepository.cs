namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class CountryRepository : ICountryRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public CountryRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }

    public async Task UpdateCountry(Expression<Func<Country, bool>> predicate, 
        string name, string countryCode, string threeLettersISOCode)
    {
        await FoudVestorContext.Countries.Where(predicate)
            .ExecuteUpdateAsync(x => 
                x.SetProperty(x => x.Name, name)
                .SetProperty(x => x.CountryCode, countryCode)
                .SetProperty(x => x.ThreeLetterISOCode, threeLettersISOCode));
    }
}