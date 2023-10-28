namespace FoudVestor.Db.Models;

[Table("InvestmentPortfolios")]
public sealed class InvestmentPortfolio
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("project_id")]
    public int ProjectId { get; set; }

    [Required]
    [Column("investor_id")]
    public int InvestorId { get; set; }

    [Required]
    [Column("amount")]
    public decimal Amount { get; set; } 

    [Required]
    [Column("currency")]
    public Currency Currency { get; set; }

    [Required]
    [Column("is_approved")]
    public bool IsApproved { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public Investor? Investor { get; set; }
    public Project? Project { get; set; }
}