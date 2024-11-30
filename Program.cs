using hotel_assignment.classes;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml.Linq;
using System;

namespace hotel_assignment
{
   
    internal class Program
    {

        static void Main(string[] args)
        {
            Room room1 = new Room("king ", 100, 1);
            Room room2 = new Room("queen", 150, 2);
            Hotel hotel1 = new Hotel("Senorita");
            hotel1.AddRoom(room1);
            hotel1.AddRoom(room2);

            Console.WriteLine("All rooms in the hotel:");
            hotel1.ShowAllRooms();


            try
            {
                Console.WriteLine("\nAttempting to reserve room with ID 1...");
                hotel1.MakeReservation(1); //reserved

                Console.WriteLine("\nAttempting to reserve room with ID 1 again...");
                hotel1.MakeReservation(1); // throw NotAvailableException
            }
            catch (NotAvailableException ex)
            {
                Console.WriteLine($"Reservation failed: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Reservation failed: {ex.Message}");
            }

            try
            {
                Console.WriteLine("\nAttempting to reserve room with ID 89...");
                hotel1.MakeReservation(89);
            }

            catch (NotAvailableException ex)
            {
                Console.WriteLine($"Reservation failed: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Reservation failed: {ex.Message}");
            }


        }


        }






    }
