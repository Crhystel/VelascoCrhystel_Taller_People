using SQLite;

namespace People.Models;
[Table("CVPeople")]
public class CVPerson
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    [MaxLength(250),Unique]
    public string Name { get; set; }
}
