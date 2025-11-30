using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;
namespace ToDoApp.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly List<ToDoItem> _items = new();
    private int _nextId = 1;

    //Assigns an id to each task as its added to the ToDo List
    public Task AddTask(ToDoItem item)
    {
        item.Id = _nextId++;
        _items.Add(new ToDoItem
        {
            Id = item.Id,
            Description = item.Description,
            IsDone = item.IsDone
        });
        return Task.CompletedTask;
    }

    //Returns a list of all of the ToDo Items
    public Task<List<ToDoItem>> GetAllTasks()
    {
        return Task.FromResult(_items.Select(i => new ToDoItem
        {
            Id = i.Id,
            Description = i.Description,
            IsDone = i.IsDone
        }).ToList());
    }

    //Removes Items based on id from the list 
    public Task<bool> RemoveTask(int id)
    {
        var existing = _items.FirstOrDefault(i => i.Id == id);
        if (existing == null) return Task.FromResult(false);
        _items.Remove(existing);
        return Task.FromResult(true);
    }
}