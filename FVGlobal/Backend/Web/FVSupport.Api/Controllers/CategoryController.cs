namespace FVSupport.Api.Controllers;

[Route("api/categories")]
[ApiController]
//[Authorize(Roles = "Admin")]
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

            if (!response.Categories!.Any())
            {
                return StatusCode(FVPlatformStatusCodes.NoContent);
            }

            return StatusCode(FVPlatformStatusCodes.Ok, response);
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, ex.Message);
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

            return StatusCode(FVPlatformStatusCodes.Created, response);
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, ex.Message);
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

            if (!response.IsSucceed)
            {
                return StatusCode(response.StatusCode, new { error = response.ErrorMessage });
            }

            return StatusCode(FVPlatformStatusCodes.Ok, response.GetResponse());
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, ex.Message);
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

            if (!response.IsSucceed)
            {
                return StatusCode(response.StatusCode, new { error = response.ErrorMessage });
            }

            return StatusCode(response.StatusCode);
        }
        catch (Exception ex)
        {
            logger.LogError("Log error message: {ex}", ex.GetBaseException().Message);

            return StatusCode(FVPlatformStatusCodes.InternalServerError, ex.Message);
        }
    }
}