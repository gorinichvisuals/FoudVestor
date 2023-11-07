namespace FVSupport.App.DTO.Country;

public sealed record CountryCreateDTO(
    [field: Required] string Name, 
    [field: Required] string CountryCode, 
    [field: Required] string ThreeLetterISOCode);