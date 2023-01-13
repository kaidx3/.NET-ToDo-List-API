using ezToDo.Models;
using Microsoft.AspNetCore.Mvc;
using udemy_api;

namespace ezToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase
{
    DataContextDapper _dapper;
    public ListController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("GetLists")]
    public IEnumerable<List> GetLists()
    {
        string sql = $"SELECT Id, Name, TaskCount, AccountID FROM List";
        IEnumerable<List> lists = _dapper.LoadData<List>(sql);
        return lists;
    }

    [HttpGet("GetList/{listId}")]
    public User GetList(int listId)
    {
        string sql = $"SELECT Id, Name, TaskCount, AccountID FROM List WHERE Id = {listId}";
        return _dapper.LoadDataSingle<User>(sql);
    }

    [HttpPut("EditList")]
    public IActionResult EditList(List list)
    {
        string sql = $"UPDATE List SET Name = '{list.Name}', TaskCount = {list.TaskCount}, AccountId = '{list.AccountId}' WHERE Id = {list.Id}";
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to update list!");
    }

    [HttpPost("AddList")]
    public IActionResult AddList(List list)
    {
        string sql = $"INSERT INTO List (Name, TaskCount, AccountId) VALUES ('{list.Name}', {list.TaskCount}, {list.AccountId})";
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to add list!");
    }

    [HttpDelete("DeleteList")]
    public IActionResult DeleteList(int listId)
    {
        string sql = $"DELETE FROM List WHERE Id = {listId}";
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to delete list!");
    }
}
