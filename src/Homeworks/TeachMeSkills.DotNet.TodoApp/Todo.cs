using System;

namespace TeachMeSkills.DotNet.TodoApp
{
    /// <summary>
    /// TodoClass.
    /// </summary>
    public class Todo
    {
        private readonly string Id = Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
        private readonly DateTime _dateTime = DateTime.Now;
        private TodoStatus _status = TodoStatus.Backlog;

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Set status.
        /// </summary>
        /// <param name="status">Status.</param>
        public void SetStatus(TodoStatus status)
        {
            _status = status;
        }

        /// <summary>
        /// Get id.
        /// </summary>
        /// <returns>Id.</returns>
        public string GetId()
        {
            return Id;
        }

        /// <summary>
        /// Get information.
        /// </summary>
        public void GetInfo()
        {
            Console.WriteLine(Id);
            Console.WriteLine("---");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Status: {_status}");
            Console.WriteLine($"DateTime: {_dateTime}");
            Console.WriteLine();
        }

        /// <summary>
        /// Convert status.
        /// </summary>
        /// <param name="status">Before converted.</param>
        /// <returns>After converted.</returns>
        public TodoStatus ConvertStatus(string status)
        {
            return status switch
            {
                "Backlog" => TodoStatus.Backlog,
                "InProgress" => TodoStatus.InProgress,
                "Done" => TodoStatus.Done,
                "Canceled" => TodoStatus.Canceled,
                _ => TodoStatus.Unknown,
            };
        }
    }
}
