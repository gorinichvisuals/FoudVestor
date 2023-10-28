namespace FoudVestor.Db.Models;

[Table("Companies")]
public sealed class Company
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(128)]
    public string? Name { get; set; }

    [Required]
    [Column("description")]
    [StringLength(4096)]
    public string? Description { get; set; }

    [Required]
    [Column("foundation_date")]
    public string? FoundationDate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public Country? Country { get; set; }
    public Category? Category { get; set; }
    public ICollection<Project>? Projects { get; set; }
    public ICollection<Founder>? Founders { get; set; }
}