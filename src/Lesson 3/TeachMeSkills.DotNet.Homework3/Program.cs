using System;
using System.Collections.Generic;
using System.Linq;

namespace TeachMeSkills.DotNet.Homework3
{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine("Enter name and description.");
                var todo = new Todo
                {
                    Name = Console.ReadLine(),
                    Description = Console.ReadLine()
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
                Console.WriteLine("Please enter todo Id");
                var userInput = Console.ReadLine();

                foreach (var todo in backlog)
                {
                    if (todo.GetId() == userInput)
                    {
                        Console.WriteLine("Enter new todo status..");
                        Console.WriteLine("Availiable statuses: InProgress, Done, Canceled");
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
            Console.WriteLine("=======");
            foreach (var todo in backlog)
            {
                todo.GetInfo();
            }
            Console.WriteLine("=======");
        }

        private static bool InputStop()
        {
            Console.Write("Stop? Press Y/y");
            var key = Console.ReadKey().Key;
            return key == ConsoleKey.Y;
        }
    }
}
