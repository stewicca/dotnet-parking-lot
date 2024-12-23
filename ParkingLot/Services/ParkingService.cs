using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.Services
{
    public class ParkingService
    {
        private readonly int _capacity;
        private readonly Dictionary<int, Vehicle> _slots;

        public ParkingService(int capacity)
        {
            _capacity = capacity;
            _slots = new Dictionary<int, Vehicle>();
            for (var i = 1; i <= _capacity; i++)
                _slots[i] = null;
        }

        public void ParkVehicle(string registrationNumber, string color, string type)
        {
            if (type != "Mobil" && type != "Motor")
            {
                Console.WriteLine("Invalid vehicle type. Only Mobil and Motor are allowed.");
                return;
            }

            var availableSlot = _slots.FirstOrDefault(s => s.Value == null).Key;

            if (availableSlot == 0)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            var vehicle = new Vehicle(registrationNumber, color, type);
            _slots[availableSlot] = vehicle;
            Console.WriteLine($"Allocated slot number: {availableSlot}");
        }

        public void LeaveSlot(int slotNumber)
        {
            if (!_slots.ContainsKey(slotNumber) || _slots[slotNumber] == null)
            {
                Console.WriteLine($"Slot number {slotNumber} is already free or invalid.");
                return;
            }

            _slots[slotNumber] = null;
            Console.WriteLine($"Slot number {slotNumber} is free");
        }

        public void ShowStatus()
        {
            Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");
            foreach (var slot in _slots.Where(s => s.Value != null))
            {
                Console.WriteLine($"{slot.Key}\t{slot.Value.RegistrationNumber}\t{slot.Value.Type}\t{slot.Value.Color}");
            }
        }

        public void CountVehiclesByType(string type)
        {
            var count = _slots.Values.Count(v => v != null && v.Type == type);
            Console.WriteLine(count);
        }

        public void RegistrationNumbersForOddPlates()
        {
            var result = _slots.Values
                .Where(v => v != null && int.Parse(v.RegistrationNumber.Split('-')[1]) % 2 != 0)
                .Select(v => v.RegistrationNumber);
            Console.WriteLine(string.Join(", ", result));
        }

        public void RegistrationNumbersForEvenPlates()
        {
            var result = _slots.Values
                .Where(v => v != null && int.Parse(v.RegistrationNumber.Split('-')[1]) % 2 == 0)
                .Select(v => v.RegistrationNumber);
            Console.WriteLine(string.Join(", ", result));
        }

        public void RegistrationNumbersByColor(string color)
        {
            var result = _slots.Values
                .Where(v => v != null && v.Color == color)
                .Select(v => v.RegistrationNumber);
            Console.WriteLine(string.Join(", ", result));
        }

        public void SlotNumbersByColor(string color)
        {
            var result = _slots
                .Where(s => s.Value != null && s.Value.Color == color)
                .Select(s => s.Key);
            Console.WriteLine(string.Join(", ", result));
        }

        public void SlotNumberByRegistrationNumber(string registrationNumber)
        {
            var slot = _slots.FirstOrDefault(s => s.Value != null && s.Value.RegistrationNumber == registrationNumber).Key;

            if (slot == 0)
            {
                Console.WriteLine("Not found");
                return;
            }

            Console.WriteLine(slot);
        }
    }
}