namespace FoudVestor.Db.Configuration;

public static class ConnectionStrings
{
    public static string FoudVestor { get; }

    static ConnectionStrings()
    {
        var binDir = string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath)
                ? AppDomain.CurrentDomain.BaseDirectory
                : AppDomain.CurrentDomain.RelativeSearchPath;

        var env = FoudVestorPlatformEnvironment.GetEnvironment();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(binDir)
            .AddJsonFile($"appsettings.{env}.dbconnection.json", false, true)
            .Build();

        FoudVestor = configuration.GetConnectionString("FoudVestor")!;
    }
}