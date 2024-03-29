﻿using System;
using System.Collections.Generic;
using System.Linq;

using EmployeeApp.Business;
using EmployeeApp.Models;

namespace EmployeeApp
{
    internal static class Program
    {
        static void Main()
        {
            EmployeeBLL employeeBLL = new EmployeeBLL();
            List<IEmployee> resultEmployees = new List<IEmployee>();

            Console.WriteLine("Welcome to the Employee App!");
            bool shouldContinueApp = true;
            bool shouldPrintMenu = true;
            do
            {
                if (shouldPrintMenu)
                {
                    Console.WriteLine(
                        "\n"
                            + "Options:\n"
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
                        Console.WriteLine("\nAll employees:");
                        resultEmployees = employeeBLL.GetAll();
                        break;

                    case "2":
                        Console.Write("What state would you like to search for?\n» ");
                        string state = Console.ReadLine();
                        Console.WriteLine($"\nEmployees who live in {state}:");
                        resultEmployees = employeeBLL.GetByState(state);
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
                        Console.WriteLine($"\nEmployees who started after {date:yyyy-MM-dd}:");
                        resultEmployees = employeeBLL.GetByStartDateAfter(date);
                        break;

                    case "4":
                        shouldContinueApp = false;
                        break;

                    default:
                        Console.WriteLine("ERROR: Invalid selection.");
                        shouldPrintMenu = false;
                        continue;
                }
                if (shouldContinueApp)
                {
                    WriteEmployees(resultEmployees);
                }
                shouldPrintMenu = true;
                resultEmployees.Clear();
            } while (shouldContinueApp);

            Console.WriteLine("Thank you for using the Employee App!");
            Console.ReadKey(intercept: true);
        }

        private static void WriteEmployees(IEnumerable<IEmployee> employees)
        {
            if (!employees.Any())
            {
                Console.WriteLine("<none>");
                return;
            }

            int nameWidth = 0;
            int addressWidth = 0;
            foreach (IEmployee employee in employees)
            {
                int nameLength = employee.FullName.Length;
                if (nameWidth < nameLength)
                {
                    nameWidth = nameLength;
                }
                int addressLength = employee.Address?.FullAddress.Length ?? 0;
                if (addressWidth < addressLength)
                {
                    addressWidth = addressLength;
                }
            }
            foreach (IEmployee employee in employees)
            {
                string dateString = "<none>";
                if (!(employee.EmploymentStartDate is null))
                {
                    dateString = ((DateTime)employee.EmploymentStartDate).ToString("yyyy-MM-dd");
                }
                Console.WriteLine(
                    string.Format($"{{0,{-nameWidth}}}\t", employee.FullName)
                        + string.Format(
                            $"Address: {{0,{-addressWidth}}}\t",
                            employee.Address?.FullAddress ?? "<none>"
                        )
                        + $"Started: {dateString}"
                );
            }
        }
    }
}
