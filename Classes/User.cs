namespace TSDZ2Monitor.Classes;

[Table("user")]
public class User
{
  // PrimaryKey is typically numeric 
  [PrimaryKey, AutoIncrement, Column("_id")]
  public int Id { get; set; }

  [MaxLength(250)]
  public string Username { get; set; }

}