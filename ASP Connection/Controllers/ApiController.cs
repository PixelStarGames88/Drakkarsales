using ASP_Connection.Models;
using ASP_Connection.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Connection.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly DataBaseConnector _dataBaseConnector;

    public AuthController(DataBaseConnector dataBaseConnector)
    {
        _dataBaseConnector = dataBaseConnector;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var userRequest = await _dataBaseConnector.DataIsCorrect(request.Login, request.Password);
        if (userRequest == null)
            return Unauthorized();

        return Ok(new UserObject { 
            Login = userRequest.Login, 
            Password = userRequest.Password, 
            FirstName = userRequest.Name.Split(' ')[0] ?? "", 
            LastName = userRequest.Name.Split(' ')[1] ?? ""});
    }

    [HttpPost("registration")]
    public async Task<IActionResult> CreateNewAccount([FromBody] CreateAccountRequest request)
    {
        if (request.Password != request.RepeatPassword)
            return BadRequest();
        if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.RepeatPassword))
            return BadRequest();

        var userRequest = await _dataBaseConnector.CreateNewAccount(request.Login, request.Password, request.FirstName, request.LastName);

        if (userRequest == null)
            return BadRequest();

        return Ok(new UserObject
        {
            Login = userRequest.Login,
            Password = userRequest.Password,
            FirstName = userRequest.Name.Split(' ')[0] ?? "",
            LastName = userRequest.Name.Split(' ')[1] ?? ""
        });
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAccount([FromBody] DeleteRequest request)
    {
        var success = await _dataBaseConnector.DeleteAccount(request.Login);

        if (!success)
            return BadRequest();

        return Ok(true);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateRequest request)
    {
        if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
            return BadRequest();

        var userRequest = await _dataBaseConnector.UpdateAccount(request.CurrentLogin, request.Login, request.Password, request.FirstName, request.LastName);

        if (userRequest == null)
            return BadRequest();

        return Ok(new UserObject
        {
            Login = userRequest.Login,
            Password = userRequest.Password,
            FirstName = userRequest.Name.Split(' ')[0] ?? "",
            LastName = userRequest.Name.Split(' ')[1] ?? ""
        });
    }
}