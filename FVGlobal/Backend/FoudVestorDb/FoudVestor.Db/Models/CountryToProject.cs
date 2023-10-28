namespace FoudVestor.Db.Models;

[Table("CountryToProjects")]
public sealed class CountryToProject
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("project_id")]
    public int ProjectId { get; set; }

    public Country? Country { get; set; }
    public Project? Project { get; set; }
}