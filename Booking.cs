using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading.Tasks;
using Asm2._2_Hotel.Models;
using Asm2._2_Hotel.Utils;
namespace Asm2._2_Hotel.Models
{
    public class Booking
    {
         public string HotelNo { get; set; }
        public string RoomNo { get; set; }
        public string CMTND { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Booking()
        {
        }

        public void Input()
        {
            if (Datacontroller.getInstance().HotelList.Count == 0)
            {
                return;
            }

            bool isFind = false;

            Console.WriteLine("Enter Hotel's ID: ");
            Hotel currentHotel = null;
            while (true)
            {
                HotelNo = Console.ReadLine();
                isFind = false;
                foreach (Hotel hotel in Datacontroller.getInstance().HotelList)
                {
                    if (hotel.HotelNo == HotelNo)
                    {
                        currentHotel = hotel;
                        isFind = true;
                        break;
                    }
                }

                if (!isFind)
                {
                    Console.WriteLine("Enter again: ");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter Room No: ");
            while (true)
            {
                RoomNo = Console.ReadLine();
                isFind = false;
                foreach (Room room in currentHotel.RoomList)
                {
                    if (room.RoomNo == RoomNo)
                    {
                        isFind = true;
                        break;
                    }
                }

                if (!isFind)
                {
                    Console.WriteLine("Enter Again: ");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter Customer ID: ");
            CMTND = Console.ReadLine();
            isFind = false;
            foreach (Customer customer in Datacontroller.getInstance().CustomerList)
            {
                if (customer.CMTND == CMTND)
                {
                    isFind = true;
                    break;
                }
            }

            if (!isFind)
            {
                Customer customer = new Customer(CMTND);
                customer.InputWithoutCMTND();

                Datacontroller.getInstance().CustomerList.Add(customer);
            }

            Console.WriteLine("Enter check in day (yyyy-MM-dd HH:mm:ss): ");
            CheckIn = Utility.ConvertStringToDateTime(Console.ReadLine());

            Console.WriteLine("Enter check out day (yyyy-MM-dd HH:mm:ss): ");
            CheckOut = Utility.ConvertStringToDateTime(Console.ReadLine());
        }
        public void Display()
        {
            Console.WriteLine("Hotel's ID: {0}, Room no: {1}, Customer's ID: {2}" +
                              "Check in day: {3}, Check out day: {4}", HotelNo, RoomNo
            , CMTND, Utility.ConvertDateTimeToString(CheckIn),
            Utility.ConvertDateTimeToString(CheckOut));
        }
    }
}