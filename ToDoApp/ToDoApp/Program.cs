using System;
using System.Threading.Tasks;
using ToDoApp.Controllers;
using ToDoApp.Repositories;
using ToDoApp.Services;

namespace ToDoApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var repo = new ToDoRepository();
            var service = new ToDoServices(repo);
            var controller = new ToDoController(service);

            while (true)
            {
                Console.WriteLine("To Do List Options:\n1.Add Item\n2.View ToDo List\n3.Remove Item\n4.Quit");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("\nEnter Description: ");
                    var description = Console.ReadLine();
                    var item = await controller.CreateToDoItem(description);
                    Console.WriteLine($"\"Added item with the ID: {item.Id}");
                }
                else if (input == "2")
                {
                    Console.WriteLine("\n");
                    var allItems = await controller.ListAll();
                    foreach (var item in allItems)
                    {
                        Console.WriteLine($"{item.Id}. {item.Description}");
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("\nEnter item id to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var item = await controller.DeleteToDoItem(id);
                        Console.WriteLine($"Item {id} has been removed.");
                    }
                    else
                    {
                        Console.WriteLine("ID not found");
                    }
                }
                else if (input == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid input, please try again");
                }
                Console.WriteLine();
            }
        }
    }
}