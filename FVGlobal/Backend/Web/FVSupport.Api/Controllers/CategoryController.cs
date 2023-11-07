namespace FVSupport.Api.Controllers;

[Route("api/categories")]
[ApiController]
[Authorize(Roles = "Admin")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService categoryService;
    private readonly ILogger<CategoryController> logger;

    public CategoryController(
        ICategoryService categoryService,
        ILogger<CategoryController> logger)
    {
        this.categoryService = categoryService;
        this.logger = logger;
    }

    [HttpGet]
    [SwaggerResponse(FVPlatformStatusCodes.Ok, type: typeof(ICollection<CategoryListDTO>))]
    [SwaggerResponse(FVPlatformStatusCodes.NoContent)]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> GetCategories(int skipItems = 0, int takeItems = 10, 
        string orderByColumn = "id", bool ascending = true, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await categoryService.GetCategories(
                skipItems, takeItems, orderByColumn, ascending, cancellationToken);

            return !response.Categories!.Any() 
                ? StatusCode(FVPlatformStatusCodes.NoContent)
                : StatusCode(FVPlatformStatusCodes.Ok, new { categories = response });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpPost]
    [SwaggerResponse(FVPlatformStatusCodes.Created, type: typeof(CategoryGetDTO))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> CreateCategory(CategoryCreateDTO createDTO)
    {
        try
        {
            var response = await categoryService.CreateCategory(createDTO);

            return StatusCode(FVPlatformStatusCodes.Created, new { category = response });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpPut("{categoryId}")]
    [SwaggerResponse(FVPlatformStatusCodes.Ok, type: typeof(CategoryGetDTO))]
    [SwaggerResponse(FVPlatformStatusCodes.BadRequest, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.NotFound, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> UpdateCountry(CategoryUpdateDTO updateDTO, int categoryId)
    {
        try
        {
            var response = await categoryService.UpdateCategory(updateDTO, categoryId);

            return response.IsSucceed
                ? StatusCode(response.StatusCode, new { category = response.GetResponse() })
                : StatusCode(response.StatusCode, new { error = response.ErrorMessage });
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, new { error = ex.Message });
        }
    }

    [HttpDelete("{categoryId}")]
    [SwaggerResponse(FVPlatformStatusCodes.Ok)]
    [SwaggerResponse(FVPlatformStatusCodes.Unauthorized, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.Forbidden, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.NotFound, type: typeof(string))]
    [SwaggerResponse(FVPlatformStatusCodes.InternalServerError, type: typeof(string))]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        try
        {
            var response = await categoryService.DeleteCategory(categoryId);

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