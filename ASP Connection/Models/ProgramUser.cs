using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ASP_Connection.Models;

[Table("program_user")]
public class ProgramUser : BaseModel
{
    [Column("user_login")]
    public string Login { get; set; } = null!;
    [Column("user_password")]
    public string Password { get; set; } = null!;
    [Column("user_name")]
    public string Name { get; set; } = null!;
}
