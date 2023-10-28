namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class CountryToCategoryRepository : ICountryToCategoryRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public CountryToCategoryRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}