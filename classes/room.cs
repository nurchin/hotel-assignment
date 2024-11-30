using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using static hotel_assignment.Program;

namespace hotel_assignment.classes
{

    internal class Room
    {
        private bool _isAvailable = true;
        private static int _idCounter = 1;
        public int Id { get; }
        public string Name { get; set; }

        public double Price { get; set; }

        public int PersonCapacity { get; set; }

        public bool IsAvailable
        {
            get
            {
                return _isAvailable;
            }
            private set
            {
                _isAvailable = value;
            }
        }

        public Room(string name, double price, int personCapacity)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can't be nonexistent");
            }
            if (price <= 0) {
                throw new ArgumentException("Price can't be less than or equal to zero");
            }
            if (personCapacity <=0 )
            {
                throw new ArgumentException("Person capacity should be more than zero");
            }
            Id= _idCounter++;
            Name=name;
            Price=price;
            PersonCapacity=personCapacity;


        }
        public void ShowInfo()
        {
            Console.WriteLine($"Room id:{Id}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Price:{Price}");
            Console.WriteLine($"Person Capacity :{PersonCapacity}");
            Console.WriteLine($"Availability:{(IsAvailable ? "Available" : "Not Available")}");


        }

        public void Reserve()
        {
            if (!IsAvailable)
            {
                throw new NotAvailableException("Room is already reserved.");
            }
            else
            {
                IsAvailable = false; 
                Console.WriteLine("Room has been reserved successfully.");
            }

        }
        
        public override string ToString()
        {
            return $"Room Info:\n ID: {Id}, Name: {Name}, Price: {Price}, Capacity: {PersonCapacity}, Availability: {(IsAvailable ? "Available" : "Not Available")}";
        }

    }

    public class NotAvailableException : Exception
    {
        public NotAvailableException(string message) : base(message) { }
    }

}