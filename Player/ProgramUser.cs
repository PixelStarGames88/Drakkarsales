using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Player;

[Table("program_user")]
public class ProgramUser : BaseModel
{
    [Column("user_login")]
    [PrimaryKey("user_login")]
    public string Login { get; set; }
    [Column("user_password")]
    public string Password { get; set; }
    [Column("user_name")]
    public string Name { get; set; }

}
