namespace FoudVestor.DataConnection.Services.Implementations;

internal sealed class CountryToProjectRepository : ICountryToProjectRepository
{
    public FoudVestorContext FoudVestorContext { get; set; }

    public CountryToProjectRepository(FoudVestorContext context)
    {
        FoudVestorContext = context;
    }
}