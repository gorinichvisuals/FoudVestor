namespace FVCommon.System;

public static class FoudVestorPlatformEnvironment
{
    public const string LocalEnvironment = "local";
    public const string DevEnvironment = "dev";
    public const string ProductionEnvironment = "prod";

    private static string CurrentEnvironment;

    private static readonly List<string> Environments = new()
    {
        LocalEnvironment, DevEnvironment, ProductionEnvironment
    };

    static FoudVestorPlatformEnvironment()
    {
        string environment = Environment.GetEnvironmentVariable("FV_ENVIRONMENT") ?? string.Empty;
        CurrentEnvironment = Environments.Contains(environment) ? environment : LocalEnvironment;
    }

    public static void SetEnvironment(string environment)
    {
        CurrentEnvironment = Environments.Contains(environment) ? environment : CurrentEnvironment;
    }

    public static string GetEnvironment()
    {
        return CurrentEnvironment;
    }
}