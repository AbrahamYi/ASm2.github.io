using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading.Tasks;
namespace Asm2._2_Hotel.Models
{
    public class Room
    {
        public string RoomNo { get; set; }
        public string RoomName { get; set; }
        public int Floor { get; set; }
        public int NumMax { get; set; }
        public string TypeOfRoom { get; set; }
        public int Price { get; set; }

        public Room()
        {

        }

        public void Input()
        {
            Console.WriteLine("Enter room no: ");
            RoomNo = Console.ReadLine();

            Console.WriteLine("Enter Room's name: ");
            RoomName = Console.ReadLine();

            Console.WriteLine("Enter Floor: ");
            Floor = int.Parse(Console.ReadLine());

            Console.WriteLine("Max people in room: ");
            NumMax = int.Parse(Console.ReadLine());

            Console.WriteLine("Room type: ");
            TypeOfRoom = Console.ReadLine();

            Console.WriteLine("Room price: ");
            Price = int.Parse(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("  Room no: {0}, Room's name: {1}, Floor: {2}, " +
                              "Max people in room: {3}, Room type: {4}, price: {5},"
                , RoomNo, RoomName, Floor, NumMax, TypeOfRoom, Price);
        }
    }
}