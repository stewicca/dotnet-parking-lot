using ParkingLot.Services;
using System;

namespace ParkingLot.Commands
{
    public class CommandHandler
    {
        private ParkingService _parkingLot;

        public void ShowMenu()
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Create Parking Lot");
            Console.WriteLine("2. Park Vehicle");
            Console.WriteLine("3. Leave Slot");
            Console.WriteLine("4. Show Status");
            Console.WriteLine("5. Count Vehicles by Type");
            Console.WriteLine("6. Registration Numbers for Odd Plates");
            Console.WriteLine("7. Registration Numbers for Even Plates");
            Console.WriteLine("8. Registration Numbers by Color");
            Console.WriteLine("9. Slot Numbers by Color");
            Console.WriteLine("10. Slot Number by Registration Number");
            Console.WriteLine("11. Exit");
        }

        public void HandleMenuSelection(int choice)
        {
            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the number of slots: ");
                        var capacity = int.Parse(Console.ReadLine());
                        _parkingLot = new ParkingService(capacity);
                        Console.WriteLine($"Created a parking lot with {capacity} slots.");
                        break;

                    case 2:
                        Console.Write("Enter registration number, color, and type (e.g., B-1234-XYZ Putih Mobil): ");
                        var vehicleInput = Console.ReadLine()?.Split(' ');
                        if (vehicleInput != null && vehicleInput.Length == 3)
                        {
                            _parkingLot?.ParkVehicle(vehicleInput[0], vehicleInput[1], vehicleInput[2]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please provide registration number, color, and type.");
                        }
                        break;

                    case 3:
                        Console.Write("Enter slot number to leave: ");
                        var slotNumber = int.Parse(Console.ReadLine());
                        _parkingLot?.LeaveSlot(slotNumber);
                        break;

                    case 4:
                        _parkingLot?.ShowStatus();
                        break;

                    case 5:
                        Console.Write("Enter vehicle type (Mobil/Motor): ");
                        string type = Console.ReadLine();
                        _parkingLot?.CountVehiclesByType(type);
                        break;

                    case 6:
                        _parkingLot?.RegistrationNumbersForOddPlates();
                        break;

                    case 7:
                        _parkingLot?.RegistrationNumbersForEvenPlates();
                        break;

                    case 8:
                        Console.Write("Enter color: ");
                        string color = Console.ReadLine();
                        _parkingLot?.RegistrationNumbersByColor(color);
                        break;

                    case 9:
                        Console.Write("Enter color: ");
                        string slotColor = Console.ReadLine();
                        _parkingLot?.SlotNumbersByColor(slotColor);
                        break;

                    case 10:
                        Console.Write("Enter registration number: ");
                        string regNumber = Console.ReadLine();
                        _parkingLot?.SlotNumberByRegistrationNumber(regNumber);
                        break;

                    case 11:
                        Console.WriteLine("Exiting program.");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}