namespace ToDoApp.Models;

//Items in the ToDo list
public class ToDoItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
}