using System;
using System.Collections.Generic;

namespace TeachMeSkills.DotNet.TodoApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var backlog = new Todo[100];
            var backlog = new List<Todo>();
            var inputStop = false;

            InputBacklogList(backlog, inputStop);
            ShowBacklog(backlog);
            ChangeBacklogTodoItemsStatus(backlog, inputStop);
            ShowBacklog(backlog);

            Console.ReadLine();
        }

        private static void InputBacklogList(List<Todo> backlog, bool inputStop)
        {
            while (!inputStop)
            {
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter description: ");
                var description = Console.ReadLine();

                var todo = new Todo
                {
                    Name = name,
                    Description = description,
                };

                //backlog[0] = todo;
                backlog.Add(todo);

                inputStop = InputStop();
                Console.WriteLine();
            }
        }

        private static void ChangeBacklogTodoItemsStatus(List<Todo> backlog, bool inputStop)
        {
            while (!inputStop)
            {
                Console.Write("Please enter todo Id: ");
                var userInput = Console.ReadLine();

                foreach (var todo in backlog)
                {
                    if (todo.GetId() == userInput.ToUpperInvariant())
                    {
                        Console.WriteLine("Todo found! Enter new todo status..");
                        Console.WriteLine("Availiable statuses: InProgress, Done, Canceled.");
                        Console.Write("Enter status: ");
                        var newStatus = Console.ReadLine();
                        todo.SetStatus(todo.ConvertStatus(newStatus));
                    }
                }

                inputStop = InputStop();
                Console.WriteLine();
            }
        }

        private static void ShowBacklog(List<Todo> backlog)
        {
            Console.WriteLine("=======\n");
            foreach (var todo in backlog)
            {
                todo.GetInfo();
            }
            Console.WriteLine("=======\n");
        }

        private static bool InputStop()
        {
            Console.Write("Stop? (Press Y/y): ");
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            return key == ConsoleKey.Y;
        }
    }
}
