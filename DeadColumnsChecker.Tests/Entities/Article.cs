using System.ComponentModel.DataAnnotations.Schema;

namespace DeadColumnsChecker.Tests.Entities;

[Table("Articles", Schema = "cms")]
public class Article
{
    public int Id { get; set; }

    public Guid CategoryId { get; set; }
}
