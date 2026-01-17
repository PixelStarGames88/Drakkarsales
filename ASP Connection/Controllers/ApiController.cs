using Microsoft.AspNetCore.Mvc;
using ASP_Connection.Services;

namespace ASP_Connection.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class ApiController : ControllerBase
{
    private readonly DataBaseConnector _dataBaseConnector;

    public ApiController(DataBaseConnector dataBaseConnector)
    {
        _dataBaseConnector = dataBaseConnector;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string login, string password)
    {
        var isValid = await _dataBaseConnector.DataIsCorrect(login, password);
        if (isValid)
            return Ok(new { Message = "Success" });
        return Unauthorized();
    }

    [HttpPost("registration")]
    public async Task<IActionResult> CreateNewAccount(string login, string password, string repeatPassword, string firstName, string lastName)
    {
        if (password != repeatPassword)
            return BadRequest();
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatPassword))
            return BadRequest();

        var success = await _dataBaseConnector.CreateNewAccount(login, password, firstName, lastName);

        if (success)
            return Ok(new { Message = "Success" });
        return BadRequest();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAccount(string login)
    {
        var success = await _dataBaseConnector.DeleteAccount(login);

        if (success) return Ok(new { Message = "Success" });

        return BadRequest();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAccount(string currentLogin, string login, string password, string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            return BadRequest();

        var success = await _dataBaseConnector.UpdateAccount(currentLogin, login, password, firstName, lastName);

        if (success) return Ok(new { Message = "Success" });

        return BadRequest();
    }
}
