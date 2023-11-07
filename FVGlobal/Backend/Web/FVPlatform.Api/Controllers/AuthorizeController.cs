namespace FVPlatform.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthorizeController : ControllerBase
{
    private readonly IAuthorizeService authorizeService;
    private readonly ILogger<AuthorizeController> logger;

    public AuthorizeController(
        IAuthorizeService authorizeService, 
        ILogger<AuthorizeController> logger)
    {
        this.authorizeService = authorizeService;
        this.logger = logger;
    }

    [HttpPost("create-founder")]
    [SwaggerResponse(FVPlatformStatusCodes.Created, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> CreateFounder(FounderCreateDTO createDTO)
    {
        try
        {
            var response = await authorizeService.CreateFounder(createDTO);

            return response.IsSucceed 
                ? StatusCode(response.StatusCode, new { token = response.GetResponse() })
                : StatusCode(response.StatusCode, new { error = response.ErrorMessage });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpPost("create-investor")]
    [SwaggerResponse(FVPlatformStatusCodes.Created, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> CreateInvestor(InvestorCreateDTO createDTO)
    {
        try
        {
            var response = await authorizeService.CreateInvestor(createDTO);

            return response.IsSucceed
                ? StatusCode(response.StatusCode, new { token = response.GetResponse() })
                : StatusCode(response.StatusCode, new { error = response.ErrorMessage });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpPost("login-founder")]
    [SwaggerResponse(FVPlatformStatusCodes.Ok, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.NotFound, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> LoginFounder(LoginDTO loginDTO)
    {
        try
        {
            var response = await authorizeService.LoginFounder(loginDTO);

            return response.IsSucceed
                ? StatusCode(response.StatusCode, new { token = response.GetResponse() })
                : StatusCode(response.StatusCode, new { error = response.ErrorMessage });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpPost("login-investor")]
    [SwaggerResponse(FVPlatformStatusCodes.Ok, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.NotFound, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> LoginInvestor(LoginDTO loginDTO)
    {
        try
        {
            var response = await authorizeService.LoginInvestor(loginDTO);

            return response.IsSucceed
                ? StatusCode(response.StatusCode, new { token = response.GetResponse() })
                : StatusCode(response.StatusCode, new { error = response.ErrorMessage });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }
}