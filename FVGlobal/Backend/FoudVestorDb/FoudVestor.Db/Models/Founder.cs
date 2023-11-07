namespace FoudVestor.Db.Models;

[Table("Founders")]
public sealed class Founder
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("company_id")]
    public int? CompanyId { get; set; }

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

    [Required]
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Required]
    [StringLength(32)]
    [Column("role")]
    public Role Role { get; set; }

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

    public ICollection<ProjectToFounder>? FounderProjects { get; set; }
    public Country? Country { get; set; }
    public Company? Company { get; set; }
    public FounderSubscription? Subscription { get; set; }
}