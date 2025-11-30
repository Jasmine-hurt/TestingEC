using ToDoApp.Models;
namespace ToDoApp.Repositories;

public interface IToDoRepository
{
    Task AddItem(ToDoItem item);
    Task<List<ToDoItem>> GetAllItems();
    Task<bool> RemoveItem(int id);
}