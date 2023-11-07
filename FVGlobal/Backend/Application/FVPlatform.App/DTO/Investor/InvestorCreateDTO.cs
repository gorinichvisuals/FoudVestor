namespace FVPlatform.App.DTO.Investor;

public sealed record InvestorCreateDTO(
    [field: Required] string FullName,
    [field: EmailAddress, Required] string Email,
    [field: Phone, Required] string Phone,
    [field: Required] int CountryId,
    [field: Required] string Address,
    [field: Required] string Password,
    InvestorSubscriptionCreateDTO SubsCreateDTO);