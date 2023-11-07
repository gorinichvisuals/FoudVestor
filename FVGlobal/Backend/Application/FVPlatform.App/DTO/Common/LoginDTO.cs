namespace FVPlatform.App.DTO.Common;

public sealed record LoginDTO(
    [field: EmailAddress, Required] string Email,
    [field: Required] string Password);