namespace FoudVestor.Db.Models;

[Table("Countries")]
public sealed class Country
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    [StringLength(64)]
    public string? Name { get; set; }

    [Required]
    [Column("country_code")]
    [StringLength(12)]
    public string? CountryCode { get; set; }

    [Required]
    [Column("three_letter_iso_code")]
    [StringLength(4)]
    public string? ThreeLetterISOCode { get; set; }

    public ICollection<Founder>? Founders { get; set; }
    public ICollection<Investor>? Investors { get; set; }
    public ICollection<Company>? Companies { get; set; }
    public ICollection<CountryToCategory>? CountryAreas { get; set; }
    public ICollection<CountryToProject>? CountryProjects { get; set; }
}