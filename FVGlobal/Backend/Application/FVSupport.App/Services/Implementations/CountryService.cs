namespace FVSupport.App.Services.Implementations;

public sealed class CountryService : ICountryService
{
    private readonly IFVDbConnection fVDbConnection;

    public CountryService(IFVDbConnection fVDbConnection)
    {
        this.fVDbConnection = fVDbConnection;
    }

    public async Task<CountryListDTO> GetCountries(int skipItems, int takeItems, 
        string orderByColumn, bool ascending, CancellationToken cancellationToken)
    {
        Expression<Func<Country, object>> sortBy = orderByColumn switch
        {
            CountryOrderConstants.Id => x => x.Id,
            CountryOrderConstants.Name => x => x.Name!,

            _ => throw new ArgumentException("Invalid order", nameof(orderByColumn))
        };

        (ICollection<CountryGetDTO> countries, int count) = await fVDbConnection.CountryRepository.GetItemListWithCount(
            x => new CountryGetDTO(x.Id, x.Name!, x.CountryCode!, x.ThreeLetterISOCode!),
            sortPredicate: sortBy,
            skipItems: skipItems, 
            takeItems: takeItems, 
            ascending: ascending,
            cancellationToken: cancellationToken);

        return new CountryListDTO(countries, count);
    }

    public async Task<CountryGetDTO> CreateCountry(CountryCreateDTO createDTO)
    {
        Country newCountry = new()
        {
            Name = createDTO.Name,
            CountryCode = createDTO.CountryCode,
            ThreeLetterISOCode = createDTO.ThreeLetterISOCode,
        };

        await fVDbConnection.CountryRepository.Create(newCountry);
        await fVDbConnection.SaveChanges();

        return new CountryGetDTO(newCountry.Id, newCountry.Name, newCountry.CountryCode, newCountry.ThreeLetterISOCode);
    }

    public async Task<AppResponse<CountryGetDTO>> UpdateCountry(CountryUpdateDTO updateDTO, int countryId)
    {
        bool countryExists = await fVDbConnection.CountryRepository.Any(x => x.Id == countryId);

        if (!countryExists) 
        {
            return AppResponse<CountryGetDTO>.Fail(FVPlatformStatusCodes.NotFound, "Country does not exists.");
        }

        await fVDbConnection.CountryRepository.UpdateCountry(x => x.Id == countryId, 
            updateDTO.Name!, updateDTO.CountryCode!, updateDTO.ThreeLetterISOCode!);

        CountryGetDTO getDTO = new(countryId, updateDTO.Name, updateDTO.CountryCode, updateDTO.ThreeLetterISOCode);

        return AppResponse<CountryGetDTO>.Success(FVPlatformStatusCodes.Ok, getDTO);
    }

    public async Task<AppResponse> DeleteCountry(int countryId)
    {
        bool countryExists = await fVDbConnection.CountryRepository.Any(x => x.Id == countryId);

        if (!countryExists)
        {
            return AppResponse.Fail(FVPlatformStatusCodes.NotFound, "Country does not exists.");
        }

        await fVDbConnection.CountryRepository.Delete(x => x.Id == countryId);

        return AppResponse.Success(FVPlatformStatusCodes.Ok);
    }
}