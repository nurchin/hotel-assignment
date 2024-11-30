using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static hotel_assignment.Program;
using System.Xml.Linq;

namespace hotel_assignment.classes
{
    internal class Hotel
    {
        public string Name {get; set;}
        private Room[] _rooms;
        public void AddRoom(Room room)
        {
            if (_rooms == null)
                _rooms = new Room[0];

            Array.Resize(ref _rooms, _rooms.Length + 1);
            _rooms[^1] = room;

        }

        public Hotel(string name)
        {
          if (string.IsNullOrEmpty(name))
          throw new ArgumentException("Hotel name cannot be null or empty.");

          Name = name;
          _rooms = new Room[0];

        }

        public void MakeReservation(int? roomId)
        {
            if (roomId == null)
                throw new ArgumentNullException(nameof(roomId), "Room ID cannot be null.");

            Room room = Array.Find(_rooms, r => r.Id == roomId);

            if (room == null)
                throw new ArgumentException($"No room found with ID {roomId}.");

            if (!room.IsAvailable)
                throw new NotAvailableException($"Room ID {roomId} is not available.");

            room.Reserve();
            Console.WriteLine($"Reservation successful for room ID {roomId}.");


        }

        public void ShowAllRooms()
        {
            Console.WriteLine($"Hotel Name: {Name}");

            if (_rooms.Length == 0)
            {
                Console.WriteLine("No rooms are available in this hotel.");
                return;
            }

            Console.WriteLine("Rooms:");
            foreach (var room in _rooms)
            {
                room.ShowInfo();
                Console.WriteLine();
            }


        }
    }


}
