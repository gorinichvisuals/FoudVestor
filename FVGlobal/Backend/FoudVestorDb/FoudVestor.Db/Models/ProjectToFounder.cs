namespace FoudVestor.Db.Models;

[Table("ProjectFounders")]
public sealed class ProjectToFounder
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("project_id")]
    public int ProjectId { get; set; }

    [Column("founder_id")]
    public int FounderId { get; set; }

    public Project? Project { get; set; }
    public Founder? Founder { get; set; }
}