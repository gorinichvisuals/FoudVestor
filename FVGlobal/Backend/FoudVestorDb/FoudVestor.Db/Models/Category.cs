namespace FoudVestor.Db.Models;

[Table("Categories")]
public sealed class Category
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    [StringLength(128)]
    public string? Name { get; set; }

    public ICollection<Project>? Projects { get; set; }
    public ICollection<InvestorArea>? AreaInvestors { get; set;}
    public ICollection<Company>? Companies { get; set; }
    public ICollection<CountryToCategory>? CategoryCountries { get; set; }
}