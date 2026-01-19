namespace ASP_Connection.Models;

public class UpdateRequest
{
    public string CurrentLogin { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
