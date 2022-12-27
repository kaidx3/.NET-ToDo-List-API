using ezToDo.Models;
using Microsoft.AspNetCore.Mvc;
using udemy_api;

namespace ezToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        string sql = $"SELECT Id, Name, Email, Password FROM Users";
        IEnumerable<User> users = _dapper.LoadData<User>(sql);
        return users;
    }

    [HttpGet("GetUser/{userId}")]
    public User GetUser(int userId)
    {
        string sql = $"SELECT Id, Name, Email, Password FROM Users WHERE Id = {userId}";
        return _dapper.LoadDataSingle<User>(sql);
    }

    [HttpGet("LoginUser/{userName}/{password}")]
    public User LoginUser(string userName, string password)
    {
        string sql = $"SELECT Id, Name, Email, Password FROM Users WHERE Name = '{userName}' AND Password = '{password}'";
        return _dapper.LoadDataSingle<User>(sql);

    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        string sql = $"UPDATE Users SET Name = '{user.Name}', Email = '{user.Email}', Password = '{user.Password}' WHERE Id = {user.Id}";
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to update user!");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(User user) 
    {
        string sql = $"INSERT INTO Users (Name, Email, Password) VALUES ('{user.Name}', '{user.Email}', '{user.Password}')";
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to add user!");
    }
}
