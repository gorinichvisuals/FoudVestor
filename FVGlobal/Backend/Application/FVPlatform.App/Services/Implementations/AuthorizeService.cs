namespace FVPlatform.App.Services.Implementations;

public sealed class AuthorizeService : IAuthorizeService
{
    private readonly IFVDbConnection fVDbConnection;
    private readonly ITokenService tokenService;

    private const int PasswordHashIterations = 9;

    public AuthorizeService(
        IFVDbConnection fVDbConnection, 
        ITokenService tokenService)
    {
        this.fVDbConnection = fVDbConnection;
        this.tokenService = tokenService;
    }

    public async Task<AppResponse<string>> CreateFounder(FounderCreateDTO createDTO)
    {
        bool countryExists = await fVDbConnection.CountryRepository.Any(x => x.Id == createDTO.CountryId);

        if (!countryExists) 
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.NotFound, "Country with this id does not exists.");
        }

        bool founderExists = await fVDbConnection.FounderRepository
            .Any(x => x.Email == createDTO.Email || x.Phone == createDTO.Phone);

        if (founderExists)
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.BadRequest, "User with this email or password does not exists.");
        }

        Founder newFounder = new()
        {
            FullName = createDTO.FullName,
            Email = createDTO.Email,
            Phone = createDTO.Phone,
            Address = createDTO.Address,
            CountryId = createDTO.CountryId,
            Role = Role.Founder,
            IsTrusted = false,
            Password = BCrypt.Net.BCrypt.HashPassword(createDTO.Password, workFactor: PasswordHashIterations),
        };

        await fVDbConnection.FounderRepository.Create(newFounder);
        await fVDbConnection.SaveChanges();

        FounderSubscription newSubscription = new()
        {
            FounderId = newFounder.Id,
            IsNotifyNewCategory = createDTO.SubsCreateDTO.IsNotifyNewCategories,
            IsNotifyNewCompanies = createDTO.SubsCreateDTO.IsNotifyNewCompanies,
            IsNotifyNewInvestors = createDTO.SubsCreateDTO.IsNotifyNewInvestors,
            IsNotifyNewInvestorsByCountry = createDTO.SubsCreateDTO.IsNotifyNewInvestorsByCountry,
            IsNotifyNewInvestorsByInvestmentArea = createDTO.SubsCreateDTO.IsNotifyNewInvestorsByInvestmentArea
        };

        await fVDbConnection.FounderSubscriptionRepository.Create(newSubscription);
        await fVDbConnection.SaveChanges();

        string token = tokenService.GenerateAccessToken(newFounder.Id, newFounder.Email, newFounder.Role);

        return AppResponse<string>.Success(FVPlatformStatusCodes.Created, token);
    }

    public async Task<AppResponse<string>> CreateInvestor(InvestorCreateDTO createDTO)
    {
        bool countryExists = await fVDbConnection.CountryRepository.Any(x => x.Id == createDTO.CountryId);

        if (!countryExists)
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.NotFound, "Country with this id does not exists.");
        }

        bool founderExists = await fVDbConnection.InvestorRepository
            .Any(x => x.Email == createDTO.Email || x.Phone == createDTO.Phone);

        if (founderExists)
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.BadRequest, "User with this email or password does not exists.");
        }

        Investor newInvestor = new()
        {
            FullName = createDTO.FullName,
            Email = createDTO.Email,
            Phone = createDTO.Phone,
            Address = createDTO.Address,
            CountryId = createDTO.CountryId,
            Role = Role.Investor,
            IsTrusted = false,
            Password = BCrypt.Net.BCrypt.HashPassword(createDTO.Password, workFactor: PasswordHashIterations),
        };

        await fVDbConnection.InvestorRepository.Create(newInvestor);
        await fVDbConnection.SaveChanges();

        InvestorSubscription newSubscription = new()
        {
            InvestorId = newInvestor.Id,
            IsNotifyNewCategory = createDTO.SubsCreateDTO.IsNotifyNewCategories,
            IsNotifyNewProjects = createDTO.SubsCreateDTO.IsNotifyNewProjects,
            IsNotifyNewCompanies = createDTO.SubsCreateDTO.IsNotifyNewCompanies,
            IsNotifyNewProjectsByCategory = createDTO.SubsCreateDTO.IsNotifyNewProjectsByCategory,
            IsNotifyNewProjectsByCoutry = createDTO.SubsCreateDTO.IsNotifyNewProjectsByCoutry,
            IsNotifyNewProjectsByFounder = createDTO.SubsCreateDTO.IsNotifyNewProjectsByFounder,
            IsNotifyNewProjectsByCompany = createDTO.SubsCreateDTO.IsNotifyNewProjectsByCompany,
            IsNotifyNewFounders = createDTO.SubsCreateDTO.IsNotifyNewFounders,
            IsNotifyNewFoundersByCoutry = createDTO.SubsCreateDTO.IsNotifyNewFoundersByCoutry
        };

        await fVDbConnection.InvestorSubscriptionRepository.Create(newSubscription);
        await fVDbConnection.SaveChanges();

        var token = tokenService.GenerateAccessToken(newInvestor.Id, newInvestor.Email, newInvestor.Role);

        return AppResponse<string>.Success(FVPlatformStatusCodes.Created, token);
    }

    public async Task<AppResponse<string>> LoginFounder(LoginDTO loginDTO)
    {
        UserInternalDTO? founder = await fVDbConnection.FounderRepository.GetOneItem(
            x => new UserInternalDTO(x.Id, x.Password!, x.Role),
            x => x.Email == loginDTO.Email);

        if (founder is null)
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.NotFound, "Founder with this email does not exists.");
        }

        if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, founder.Password))
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.BadRequest, "Wrong password.");
        }

        string token = tokenService.GenerateAccessToken(founder.UserId, loginDTO.Email, founder.Role);

        await fVDbConnection.FounderRepository.UpdateLastLogin(x => x.Id == founder.UserId);

        return AppResponse<string>.Success(FVPlatformStatusCodes.Ok, token);
    }

    public async Task<AppResponse<string>> LoginInvestor(LoginDTO loginDTO)
    {
        UserInternalDTO? investor = await fVDbConnection.InvestorRepository.GetOneItem(
            x => new UserInternalDTO(x.Id, x.Password!, x.Role),
            x => x.Email == loginDTO.Email);

        if (investor is null)
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.NotFound, "Investor with this email does not exists.");
        }

        if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, investor.Password))
        {
            return AppResponse<string>.Fail(FVPlatformStatusCodes.BadRequest, "Wrong password.");
        }

        string token = tokenService.GenerateAccessToken(investor.UserId, loginDTO.Email, investor.Role);

        await fVDbConnection.InvestorRepository.UpdateLastLogin(x => x.Id == investor.UserId);

        return AppResponse<string>.Success(FVPlatformStatusCodes.Ok, token);
    }
}