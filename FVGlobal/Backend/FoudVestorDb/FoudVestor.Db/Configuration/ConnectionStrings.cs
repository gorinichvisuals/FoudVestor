namespace FoudVestor.Db.Configuration;

public static class ConnectionStrings
{
    public static string FoudVestor { get; }

    static ConnectionStrings()
    {
        // Use binDir for Api
        var binDir = string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath)
                ? AppDomain.CurrentDomain.BaseDirectory
                : AppDomain.CurrentDomain.RelativeSearchPath;

        //Use binDir for Migrations
        //var binDir = Directory.GetCurrentDirectory();

        var env = FoudVestorPlatformEnvironment.GetEnvironment();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(binDir)
            .AddJsonFile($"appsettings.{env}.dbconnection.json", optional: false, reloadOnChange: true)
            .Build();

        FoudVestor = configuration.GetConnectionString("FoudVestor")!;
    }
}