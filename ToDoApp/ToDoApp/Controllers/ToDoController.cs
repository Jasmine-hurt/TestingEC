using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;
namespace ToDoApp.Controllers;

public class ToDoController
{
    private readonly IToDoService _toDoService;
    
    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    public async Task<ToDoItem> CreateToDoItem(string description)
    {
        return await _toDoService.CreateToDoItem(description);
    }
    
    public async Task<List<ToDoItem>> ListAll()
    {
        return await _toDoService.GetAllToDoItems();
    }

    public async Task<bool> DeleteToDoItem(int id)
    {
        return await _toDoService.DeleteToDoItem(id);
    }
}