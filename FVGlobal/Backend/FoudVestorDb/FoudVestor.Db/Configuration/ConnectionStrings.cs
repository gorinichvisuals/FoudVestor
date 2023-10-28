namespace FoudVestor.Db.Configuration;

public static class ConnectionStrings
{
    public static string FoudVestor { get; }

    static ConnectionStrings()
    {
        // Variable not worked when try add new migrations
        //var binDir = string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath)
        //        ? AppDomain.CurrentDomain.BaseDirectory
        //        : AppDomain.CurrentDomain.RelativeSearchPath;

        var env = FoudVestorPlatformEnvironment.GetEnvironment();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{env}.dbconnection.json", optional: false, reloadOnChange: true)
            .Build();

        FoudVestor = configuration.GetConnectionString("FoudVestor")!;
    }
}