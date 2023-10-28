namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class CountryRepository : ICountryRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public CountryRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}