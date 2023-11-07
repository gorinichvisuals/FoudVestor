namespace FVSupport.App.DTO.Category;

public sealed record CategoryListDTO(
    ICollection<CategoryGetDTO> Categories, 
    int Count);