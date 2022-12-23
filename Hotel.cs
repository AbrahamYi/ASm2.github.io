using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading.Tasks;
namespace Asm2._2_Hotel.Models
{
    public class Hotel
    {
         public List<Room> RoomList { get; set; }
        public string HotelNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Hotel()
        {
            RoomList = new List<Room>();
        }

        public void Input()
        {
            Console.WriteLine("Enter hotel's ID: ");
            HotelNo = Console.ReadLine();

            Console.WriteLine("Enter hotel's name: ");
            Name = Console.ReadLine();

            Console.WriteLine("Address: ");
            Address = Console.ReadLine();

            Console.WriteLine("Enter number of room to add: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Room room = new Room();
                room.Input();

                RoomList.Add(room);
            }
        }

        public void DisplayAll()
        {
            Console.WriteLine("  Hotel name: {0}, Hotel's ID: {1}, Address: {2},",
                Name, HotelNo, Address);
            Console.WriteLine("Room List: ");
            foreach (Room room in RoomList)
            {
                room.Display();
            }
        }
        public void Display()
        {
            Console.WriteLine("Hotel name: {0}, Hotel ID: {1}, Address: {2}",
                Name, HotelNo, Address);
        }

        Room findRoom(string roomNo)
        {
            foreach (Room room in RoomList)
            {
                if (room.RoomNo == roomNo)
                {
                    return room;
                }
            }
            return null;
        }
        public int CalculateProfit(List<Booking> bookings)
        {
            int profit = 0;
            foreach (Booking booking in bookings)
            {
                if (booking.HotelNo == HotelNo)
                {
                    Room room = findRoom(booking.RoomNo);
                    if (room != null)
                    {
                        profit += room.Price;
                    }
                }
            }
            return profit;
        }
        public void ShowRoomAvailable(List<Booking> bookings)
        {
            Display();
            Console.WriteLine("List of available room: ");
            foreach (Room room in RoomList)
            {
                if (CheckAvailable(bookings, room))
                {
                    room.Display();
                }
            }
        }
        bool CheckAvailable(List<Booking> bookings, Room room)
        {
            foreach (Booking booking in bookings)
            {
                if (booking.HotelNo == HotelNo && booking.RoomNo == room.RoomNo)
                {
                    return false;
                }
            }
            return true;
        }
    }
}