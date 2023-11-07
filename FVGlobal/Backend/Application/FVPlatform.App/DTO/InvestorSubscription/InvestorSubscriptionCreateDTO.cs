namespace FVPlatform.App.DTO.InvestorSubscription;

public sealed record InvestorSubscriptionCreateDTO(
    bool IsNotifyNewCategories,
    bool IsNotifyNewProjects,
    bool IsNotifyNewCompanies,
    bool IsNotifyNewProjectsByCategory,
    bool IsNotifyNewProjectsByCoutry,
    bool IsNotifyNewProjectsByFounder,
    bool IsNotifyNewProjectsByCompany,
    bool IsNotifyNewFounders,
    bool IsNotifyNewFoundersByCoutry);