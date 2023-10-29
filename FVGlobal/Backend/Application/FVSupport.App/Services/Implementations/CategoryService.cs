namespace FVSupport.App.Services.Implementations;

public sealed class CategoryService : ICategoryService
{
    private readonly IFVDbConnection fVDbConnection;

    public CategoryService(IFVDbConnection fVDbConnection)
    {
        this.fVDbConnection = fVDbConnection;
    }

    public async Task<CategoryListDTO> GetCategories(int skipItems, int takeItems, 
        string orderByColumn, bool ascending, CancellationToken cancellationToken)
    {
        Expression<Func<Category, object>> sortBy = orderByColumn switch
        {
            CategoryOrderConstants.Id => x => x.Id,
            CategoryOrderConstants.Name => x => x.Name!,

            _ => throw new ArgumentException("Invalid order", nameof(orderByColumn))
        };

        (ICollection<CategoryGetDTO> categories, int count) = 
            await fVDbConnection.CategoryRepository.GetItemListWithCount(
                x => new CategoryGetDTO(x.Id, x.Name!),
                sortPredicate: sortBy,
                skipItems: skipItems,
                takeItems: takeItems,
                ascending: ascending,
                cancellationToken: cancellationToken);

        return new CategoryListDTO(categories, count);
    }

    public async Task<CategoryGetDTO> CreateCategory(CategoryCreateDTO createDTO)
    {
        Category newCategory = new()
        {
            Name = createDTO.Name,
        };

        await fVDbConnection.CategoryRepository.Create(newCategory);
        await fVDbConnection.SaveChanges();

        return new CategoryGetDTO(newCategory.Id, newCategory.Name);
    }

    public async Task<AppResponse<CategoryGetDTO>> UpdateCategory(CategoryUpdateDTO updateDTO, int categoryId)
    {
        bool categoryExists = await fVDbConnection.CategoryRepository.Any(x => x.Id == categoryId);

        if (!categoryExists)
        {
            return AppResponse<CategoryGetDTO>.Fail(FVPlatformStatusCodes.NotFound, "Category does not exists.");
        };

        await fVDbConnection.CategoryRepository.UpdateCategory(x => x.Id == categoryId, updateDTO.Name);

        CategoryGetDTO getDTO = new(categoryId, updateDTO.Name);

        return AppResponse<CategoryGetDTO>.Success(FVPlatformStatusCodes.Ok, getDTO);
    }

    public async Task<AppResponse> DeleteCategory(int categoryId)
    {
        bool categoryExists = await fVDbConnection.CategoryRepository.Any(x => x.Id == categoryId);

        if (!categoryExists)
        {
            return AppResponse.Fail(FVPlatformStatusCodes.NotFound, "Category does not exists.");
        }

        await fVDbConnection.CategoryRepository.Delete(x => x.Id == categoryId);

        return AppResponse.Success(FVPlatformStatusCodes.Ok);
    }
}