namespace FoudVestor.Db.Models;

[Table("InvestorSubscriptions")]
public sealed class InvestorSubscription
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("investor_id")]
    public int InvestorId { get; set; }

    [Column("is_notify_new_category")]
    public bool IsNotifyNewCategory { get; set; }

    [Column("is_notify_new_projects")]
    public bool IsNotifyNewProjects { get; set; }

    [Column("is_notify_new_companies")]
    public bool IsNotifyNewCompanies { get; set; }

    [Column("is_notify_new_projects_by_category")]
    public bool IsNotifyNewProjectsByCategory { get; set; }

    [Column("is_notify_new_projects_by_country")]
    public bool IsNotifyNewProjectsByCoutry { get; set; }

    [Column("is_notify_new_projects_by_founder")]
    public bool IsNotifyNewProjectsByFounder { get; set; }

    [Column("is_notify_new_projects_by_company")]
    public bool IsNotifyNewProjectsByCompany { get; set; }

    [Column("is_notify_new_founders")]
    public bool IsNotifyNewFounders { get; set; }

    [Column("is_notify_new_founders_by_country")]
    public bool IsNotifyNewFoundersByCoutry { get; set; }

    public Investor? Investor { get; set; }
}