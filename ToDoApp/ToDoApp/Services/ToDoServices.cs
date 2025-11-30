using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Repositories;
namespace ToDoApp.Services;

public class ToDoServices :IToDoService
{
    private readonly IToDoRepository  _repository;

    public ToDoServices(IToDoRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ToDoItem> CreateToDoItem(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(nameof(description));
        }

        ToDoItem item = new ToDoItem()
        {
            Description = description,
            IsDone = false
        };
        
        await _repository.AddItem(item);

        return item;
    }

    public Task<List<ToDoItem>> GetAllToDoItems()
    {
        return _repository.GetAllItems();
    }

    public Task<bool> DeleteToDoItem(int id)
    {
        return _repository.RemoveItem(id);
    }
}