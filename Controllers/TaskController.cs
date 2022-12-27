using ezToDo.Models;
using Microsoft.AspNetCore.Mvc;
using udemy_api;

namespace ezToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    DataContextDapper _dapper;
    public TaskController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("GetTasks")]
    public IEnumerable<Models.Task> GetTasks()
    {
        string sql = $"SELECT Id, Name, Description, ListID FROM Task";
        IEnumerable<Models.Task> tasks = _dapper.LoadData<Models.Task>(sql);
        return tasks;
    }

    [HttpGet("GetTask/{taskId}")]
    public Models.Task GetTask(int taskId)
    {
        string sql = $"SELECT Id, Name, Description, ListID FROM Task WHERE Id = {taskId}";
        return _dapper.LoadDataSingle<Models.Task>(sql);
    }

    [HttpPut("EditTask")]
    public IActionResult EditTask(Models.Task task)
    {
        string sql = $"UPDATE Task SET Name = '{task.Name}', Description = '{task.Description}', ListId = '{task.ListId}' WHERE Id = {task.Id}";
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to update list!");
    }

    [HttpPost("AddTask")]
    public IActionResult AddTask(Models.Task task)
    {
        string sql = $"INSERT INTO Task (Name, Description, ListId) VALUES ('{task.Name}', '{task.Description}', {task.ListId})";
        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to add list!");
    }
}
