using System;
using System.Reflection;
using DbUp;
using OP.RememberTheDate.Configuration;

namespace OP.RememberTheDate.DatabaseSync
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = RememberTheDateConfigurationContainer.Get().Common.DatabaseConnectionString;

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
