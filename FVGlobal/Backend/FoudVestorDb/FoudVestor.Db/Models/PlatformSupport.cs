namespace FoudVestor.Db.Models;

[Table("PlatformSupports")]
public sealed class PlatformSupport
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

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
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column("last_login_time")]
    public DateTime LastLoginTime { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("role")]
    [StringLength(32)]
    [Required]
    public Role Role { get; set; }

    [Required]
    [Column("password")]
    public string? Password { get; set; }
}