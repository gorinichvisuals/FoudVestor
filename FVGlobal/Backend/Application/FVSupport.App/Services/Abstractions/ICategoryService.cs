namespace FVSupport.App.Services.Abstractions;

public interface ICategoryService
{
    Task<CategoryListDTO> GetCategories(int skipItems, int takeItems,
        string orderByColumn, bool ascending, CancellationToken cancellationToken);
    Task<CategoryGetDTO> CreateCategory(CategoryCreateDTO createDTO);
    Task<AppResponse<CategoryGetDTO>> UpdateCategory(CategoryUpdateDTO updateDTO, int categoryId);
    Task<AppResponse> DeleteCategory(int categoryId);
}