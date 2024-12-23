using ParkingLot.Commands;
using System;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandHandler = new CommandHandler();

            while (true)
            {
                commandHandler.ShowMenu();
                Console.Write("\nEnter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    commandHandler.HandleMenuSelection(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}