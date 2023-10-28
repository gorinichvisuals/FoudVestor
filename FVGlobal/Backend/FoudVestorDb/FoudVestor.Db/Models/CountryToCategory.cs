namespace FoudVestor.Db.Models;

[Table("CountryToCategories")]
public sealed class CountryToCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    public Country? Country { get; set; }
    public Category? Category { get; set; }
}