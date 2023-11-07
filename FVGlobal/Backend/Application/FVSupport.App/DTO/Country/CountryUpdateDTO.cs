namespace FVSupport.App.DTO.Country;

public sealed record CountryUpdateDTO(
    [field: Required] string Name, 
    [field: Required] string CountryCode, 
    [field: Required] string ThreeLetterISOCode);