namespace FVSupport.Api.Controllers;

[Route("api/countries")]
[ApiController]
[Authorize(Roles = "Admin")]
public class CountryController : ControllerBase
{
    private readonly ICountryService countryService;
    private readonly ILogger<CountryController> logger;

    public CountryController(
        ICountryService countryService,
        ILogger<CountryController> logger)
    {
        this.countryService = countryService;
        this.logger = logger;
    }

    [HttpGet]
    [SwaggerResponse(FVPlatformStatusCodes.Ok, type: typeof(ICollection<CountryListDTO>))]
    [SwaggerResponse(FVPlatformStatusCodes.NoContent)]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> GetCountries(int skipItems = 0, int takeItems = 10,
        string orderByColumn = "id", bool ascending = true, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await countryService.GetCountries(
                skipItems, takeItems, orderByColumn, ascending, cancellationToken);

            if (!response.Countries!.Any()) 
            {
                return StatusCode(FVPlatformStatusCodes.NoContent);
            }

            return StatusCode(FVPlatformStatusCodes.Ok, response);
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpPost]
    [SwaggerResponse(FVPlatformStatusCodes.Created, type: typeof(CountryGetDTO))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> CreateCountry(CountryCreateDTO createDTO)
    {
        try
        {
            var response = await countryService.CreateCountry(createDTO);

            return StatusCode(FVPlatformStatusCodes.Created, new { country = response });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpPut("{countryId}")]
    [SwaggerResponse(FVPlatformStatusCodes.Ok, type: typeof(CountryGetDTO))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.NotFound, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> UpdateCountry(CountryUpdateDTO updateDTO, int countryId)
    {
        try
        {
            var response = await countryService.UpdateCountry(updateDTO, countryId);

            return response.IsSucceed
                ? StatusCode(response.StatusCode, new { country = response.GetResponse() })
                : StatusCode(response.StatusCode, new { error = response.ErrorMessage });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpDelete("{countryId}")]
    [SwaggerResponse(FVPlatformStatusCodes.Ok)]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.NotFound, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> DeleteCountry(int countryId)
    {
        try
        {
            var response = await countryService.DeleteCountry(countryId);

            return response.IsSucceed
                ? StatusCode(response.StatusCode)
                : StatusCode(response.StatusCode, new { error = response.ErrorMessage });
        }
        catch (Exception ex) 
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }
}