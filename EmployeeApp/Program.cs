using System;

namespace EmployeeApp
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Employee App!");

            bool shouldContinueApp = true;
            bool shouldPrintMenu = true;
            do
            {
                if (shouldPrintMenu)
                {
                    Console.WriteLine(
                        "Options:\n"
                            + "- [1] See a list of all employees and their Addresses and Start Dates\n"
                            + "- [2] See all employees who live in a certain state\n"
                            + "- [3] See all employees who started after a certain date\n"
                            + "- [4] Exit"
                    );
                }
                Console.Write("What would you like to do?\n» ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("All employees:");
                        Console.WriteLine("<EMPLOYEES>");
                        break;
                    case "2":
                        Console.Write("What state would you like to search for?\n» ");
                        string state = Console.ReadLine();
                        Console.WriteLine($"Employees who live in {state}:");
                        Console.WriteLine("<EMPLOYEES>");
                        break;
                    case "3":
                        Console.WriteLine("What date would you like to search for?");
                        Console.Write("» ");
                        DateTime date;
                        while (!DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            Console.WriteLine("ERROR: Invalid date format.");
                            Console.Write("» ");
                        }
                        Console.WriteLine($"Employees who started after {date}:");
                        Console.WriteLine("<EMPLOYEES>");
                        break;
                    case "4":
                        shouldContinueApp = false;
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid selection.");
                        shouldPrintMenu = false;
                        continue;
                }
                shouldPrintMenu = true;
            } while (shouldContinueApp);

            Console.WriteLine("Thank you for using the Employee App!");
            Console.ReadKey(intercept: true);
        }
    }
}
