using ToDoApp.Models;
namespace ToDoApp.Repositories;

public interface IToDoRepository
{
    Task AddTask(ToDoItem item);
    Task<List<ToDoItem>> GetAllTasks();
    Task<bool> RemoveTask(int id);
}