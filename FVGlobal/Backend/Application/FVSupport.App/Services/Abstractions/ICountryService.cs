namespace FVSupport.App.Services.Abstractions;

public interface ICountryService
{
    public Task<CountryListDTO> GetCountries(int skipItems, int takeItems,
        string orderByColumn, bool ascending, CancellationToken cancellationToken);
    public Task<CountryGetDTO> CreateCountry(CountryCreateDTO createDTO);
    public Task<AppResponse<CountryGetDTO>> UpdateCountry(CountryUpdateDTO updateDTO, int countryId);
    public Task<AppResponse> DeleteCountry(int countryId);
}