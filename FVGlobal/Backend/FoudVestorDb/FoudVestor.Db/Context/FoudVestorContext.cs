namespace FoudVestor.Db.Context;

public class FoudVestorContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Investor> Investors { get; set; }
    public DbSet<Founder> Founders { get; set; }
    public DbSet<InvestmentPortfolio> InvestmentPortfolios { get; set; }
    public DbSet<PlatformSupport> PlatformSupports { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryToCategory> CountryToCategories { get; set; }
    public DbSet<CountryToProject> CountryToProjects { get; set; }
    public DbSet<FounderSubscription> FoundersSubscriptions { get; set; }
    public DbSet<InvestorSubscription> InvestorSubscriptions { get; set; }
    public DbSet<InvestorArea> InvestorAreas { get; set; }
    public DbSet<ProjectToFounder> ProjectFounders { get; set; }
    public DbSet<Company> Companies { get; set; }

    public FoudVestorContext()
    {
            
    }

    public FoudVestorContext(DbContextOptions<FoudVestorContext> options) : base(options) 
    { 

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.FoudVestor);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Founder>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Founder>().HasIndex(x => x.Phone).IsUnique();
        modelBuilder.Entity<Founder>().Property(x => x.Role).HasConversion<string>();
        modelBuilder.Entity<Founder>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Founder>().Property(x => x.LastLoginTime).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Founder>().Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Investor>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Investor>().HasIndex(x => x.Phone).IsUnique();
        modelBuilder.Entity<Investor>().Property(x => x.Role).HasConversion<string>();
        modelBuilder.Entity<Investor>().Property(x => x.Currency).HasConversion<string>();
        modelBuilder.Entity<Investor>().Property(x => x.Balance).HasPrecision(14, 2);
        modelBuilder.Entity<Investor>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Investor>().Property(x => x.LastLoginTime).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Investor>().Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<PlatformSupport>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<PlatformSupport>().HasIndex(x => x.Phone).IsUnique();
        modelBuilder.Entity<PlatformSupport>().Property(x => x.Role).HasConversion<string>();
        modelBuilder.Entity<PlatformSupport>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<PlatformSupport>().Property(x => x.LastLoginTime).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<PlatformSupport>().Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<InvestmentPortfolio>().Property(x => x.Currency).HasConversion<string>();
        modelBuilder.Entity<InvestmentPortfolio>().Property(x => x.Amount).HasPrecision(14, 2);
        modelBuilder.Entity<InvestmentPortfolio>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<InvestmentPortfolio>().Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Project>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Project>().Property(x => x.Currency).HasConversion<string>();
        modelBuilder.Entity<Project>().Property(x => x.Stage).HasConversion<string>();
        modelBuilder.Entity<Project>().Property(x => x.NecessaryFunds).HasPrecision(14, 2);
        modelBuilder.Entity<Project>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Project>().Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Country>().HasIndex(x => x.CountryCode).IsUnique();
        modelBuilder.Entity<Country>().HasIndex(x => x.ThreeLetterISOCode).IsUnique();

        modelBuilder.Entity<Company>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Company>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Company>().Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Founder>().HasOne(x => x.Company).WithMany(x => x.Founders).HasForeignKey(x => x.CompanyId);
        modelBuilder.Entity<Founder>().HasOne(x => x.Country).WithMany(x => x.Founders).HasForeignKey(x => x.CountryId);
        modelBuilder.Entity<Founder>().HasOne(x => x.Subscription).WithOne(x => x.Founder).HasForeignKey<FounderSubscription>(x => x.FounderId);

        modelBuilder.Entity<ProjectToFounder>().HasKey(x => new { x.FounderId, x.ProjectId });
        modelBuilder.Entity<ProjectToFounder>().HasOne(x => x.Founder).WithMany(x => x.FounderProjects).HasForeignKey(x => x.FounderId);
        modelBuilder.Entity<ProjectToFounder>().HasOne(x => x.Project).WithMany(x => x.ProjectFounders).HasForeignKey(x => x.ProjectId);

        modelBuilder.Entity<Investor>().HasOne(x => x.Country).WithMany(x => x.Investors).HasForeignKey(x => x.CountryId); ;
        modelBuilder.Entity<Investor>().HasOne(x => x.Subscription).WithOne(x => x.Investor).HasForeignKey<InvestorSubscription>(x => x.InvestorId);

        modelBuilder.Entity<InvestorArea>().HasKey(x => new { x.InvestorId, x.CategoryId });
        modelBuilder.Entity<InvestorArea>().HasOne(x => x.Investor).WithMany(x => x.InvestorAreas).HasForeignKey(x => x.InvestorId);
        modelBuilder.Entity<InvestorArea>().HasOne(x => x.Category).WithMany(x => x.AreaInvestors).HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<InvestmentPortfolio>().HasKey(x => new { x.InvestorId, x.ProjectId });
        modelBuilder.Entity<InvestmentPortfolio>().HasOne(x => x.Investor).WithMany(x => x.InvestmentPortfolios).HasForeignKey(x => x.InvestorId);
        modelBuilder.Entity<InvestmentPortfolio>().HasOne(x => x.Project).WithMany(x => x.InvestmentPortfolios).HasForeignKey(x => x.ProjectId);

        modelBuilder.Entity<Company>().HasOne(x => x.Country).WithMany(x => x.Companies).HasForeignKey(x => x.CountryId);
        modelBuilder.Entity<Company>().HasOne(x => x.Category).WithMany(x => x.Companies).HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<Project>().HasOne(x => x.Category).WithMany(x => x.Projects).HasForeignKey(x => x.CategoryId);
        modelBuilder.Entity<Project>().HasOne(x => x.Company).WithMany(x => x.Projects).HasForeignKey(x => x.CompanyId);

        modelBuilder.Entity<CountryToProject>().HasKey(x => new { x.CountryId, x.ProjectId });
        modelBuilder.Entity<CountryToProject>().HasOne(x => x.Country).WithMany(x => x.CountryProjects).HasForeignKey(x => x.CountryId);
        modelBuilder.Entity<CountryToProject>().HasOne(x => x.Project).WithMany(x => x.ProjectCountries).HasForeignKey(x => x.ProjectId);

        modelBuilder.Entity<CountryToCategory>().HasKey(x => new { x.CountryId, x.CategoryId });
        modelBuilder.Entity<CountryToCategory>().HasOne(x => x.Country).WithMany(x => x.CountryAreas).HasForeignKey(x => x.CountryId);
        modelBuilder.Entity<CountryToCategory>().HasOne(x => x.Category).WithMany(x => x.CategoryCountries).HasForeignKey(x => x.CategoryId);

        base.OnModelCreating(modelBuilder); 
    }
}