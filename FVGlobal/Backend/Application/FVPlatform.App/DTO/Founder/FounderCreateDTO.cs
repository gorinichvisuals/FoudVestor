namespace FVPlatform.App.DTO.Founder;

public sealed record FounderCreateDTO(
    [field: Required] string FullName,
    [field: EmailAddress, Required] string Email, 
    [field: Phone, Required] string Phone,
    [field: Required] int CountryId,
    [field: Required] string Address,
    [field: Required] string Password,
    FounderSubscriptionCreateDTO SubsCreateDTO);