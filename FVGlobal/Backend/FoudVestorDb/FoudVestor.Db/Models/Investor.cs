namespace FoudVestor.Db.Models;

[Table("Investors")]
public sealed class Investor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("country_id")]
    public int CountryId { get; set; }

    [Required]
    [StringLength(128)]
    [Column("full_name")]
    public string? FullName { get; set; }

    [Required]
    [StringLength(256)]
    [Column("email")]
    public string? Email { get; set; }

    [Required]
    [StringLength(16)]
    [Column("phone")]
    public string? Phone { get; set; }

    [Required]
    [StringLength(64)]
    [Column("address")]
    public string? Address { get; set; }

    [Required]
    [Column("is_trusted")]
    public bool IsTrusted { get; set; }

    [Column("role")]
    [StringLength(32)]
    [Required]
    public Role Role { get; set; }

    [Column("balance")]
    public decimal? Balance { get; set; }

    [Required]
    [Column("currency")]
    public Currency Currency { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column("last_login_time")]
    public DateTime LastLoginTime { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Required]
    [Column("password")]
    public string? Password { get; set; }

    public Country? Country { get; set; }
    public InvestorSubscription? Subscription { get; set; }
    public ICollection<InvestorArea>? InvestorAreas { get; set; }
    public ICollection<InvestmentPortfolio>? InvestmentPortfolios { get; set; }
}