namespace FVPlatform.App.Services.Abstractions;

public interface IAuthorizeService
{
    Task<AppResponse<string>> CreateFounder(FounderCreateDTO createDTO);
    Task<AppResponse<string>> CreateInvestor(InvestorCreateDTO createDTO);
    Task<AppResponse<string>> LoginFounder(LoginDTO loginDTO);
    Task<AppResponse<string>> LoginInvestor(LoginDTO loginDTO);
}