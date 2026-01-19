namespace ASP_Connection.Models;

public class CreateAccountRequest
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string RepeatPassword { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
