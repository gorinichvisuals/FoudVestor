namespace FoudVestor.Db.Models;

[Table("Projects")]
public sealed class Project
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("company_id")]
    public int? CompanyId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(128)]
    public string? Name { get; set; }

    [Required]
    [Column("description")]
    [StringLength(4096)]
    public string? Description { get; set; }

    [Column("is_verified")]
    public bool IsVerified { get; set; }

    [Required]
    [Column("necessary_funds")]
    public decimal NecessaryFunds { get; set; }

    [Required]
    [Column("currency")]
    public Currency Currency { get; set; }

    [Column("project_video_presentation_url")]
    [StringLength(1024)]
    public string? ProjectVideoPresentationURL { get; set; }

    [Column("foundation_date")]
    public string? FoundationDate { get; set; }

    [Required]
    [Column("stage")]
    [StringLength(24)]
    public ProjectStage Stage { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public Category? Category { get; set; }
    public Company? Company { get; set; }
    public ICollection<ProjectToFounder>? ProjectFounders { get; set; }
    public ICollection<InvestmentPortfolio>? InvestmentPortfolios { get; set; }
    public ICollection<CountryToProject>? ProjectCountries { get; set; }
}