namespace FoudVestor.Db.Models;

[Table("InvestorAreas")]
public sealed class InvestorArea
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("investor_id")]
    public int InvestorId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }
    public Investor? Investor { get; set; }
    public Category? Category { get; set; }
}