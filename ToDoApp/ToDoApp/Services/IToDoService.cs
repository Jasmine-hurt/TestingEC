using ToDoApp.Models;

namespace ToDoApp.Services;

public interface IToDoService
{
    Task<ToDoItem> CreateToDoItem(string description);
    Task<List<ToDoItem>> GetAllToDoItems();
    Task<bool> DeleteToDoItem(int id);
}