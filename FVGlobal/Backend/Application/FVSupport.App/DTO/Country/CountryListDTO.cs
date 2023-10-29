namespace FVSupport.App.DTO.Country;

public sealed record CountryListDTO(ICollection<CountryGetDTO> Countries, int Count);