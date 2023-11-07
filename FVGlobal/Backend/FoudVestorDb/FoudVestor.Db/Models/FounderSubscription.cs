namespace FoudVestor.Db.Models;

[Table("FounderSubscriptions")]
public sealed class FounderSubscription
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("founder_id")]
    public int FounderId { get; set; }

    [Column("is_notify_new_category")]
    public bool IsNotifyNewCategory { get; set; }

    [Column("is_notify_new_companies")]
    public bool IsNotifyNewCompanies { get; set; }

    [Column("is_notify_new_investors")]
    public bool IsNotifyNewInvestors { get; set; }

    [Column("is_notify_new_investors_by_investment_area")]
    public bool IsNotifyNewInvestorsByInvestmentArea { get; set; }

    [Column("is_notify_new_investors_by_country")]
    public bool IsNotifyNewInvestorsByCountry { get; set; }

    public Founder? Founder { get; set; }
}