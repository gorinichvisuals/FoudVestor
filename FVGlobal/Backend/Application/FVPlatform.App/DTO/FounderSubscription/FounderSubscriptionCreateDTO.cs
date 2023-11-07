namespace FVPlatform.App.DTO.FounderSubscription;

public sealed record FounderSubscriptionCreateDTO(
    bool IsNotifyNewCategories,
    bool IsNotifyNewCompanies,
    bool IsNotifyNewInvestors,
    bool IsNotifyNewInvestorsByInvestmentArea,
    bool IsNotifyNewInvestorsByCountry);