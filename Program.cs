using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading.Tasks;
using Asm2._2_Hotel.Models;
using Asm2._2_Hotel.Utils;
namespace Asm2._2_Hotel
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int opt;
            do
            {
                ShowMenu();
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        InputHotel();
                        break;
                    case 2:
                        DisplayHotel();
                        break;
                    case 3:
                        InputBooking();
                        break;
                    case 4:
                        FindRoomAvailable();
                        break;
                    case 5:
                        CalculateProfit();
                        break;
                    case 6:
                        SearchCustomerByCMNTD();
                        break;
                    case 7:
                        
                        break;
                    case 8:
                        Delete();
                        break;
                    case 9:
                            
                        Console.WriteLine("Exit!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!! ");
                        break;
                }
            } while (opt != 9);
            ShowMenu();
        }
        private static void Delete()
        {
            Console.WriteLine("Enter hotel's ID:");
            String hotelNo = Console.ReadLine();
            foreach(Hotel hotel in Datacontroller.getInstance().HotelList)
            {
                if (hotel.HotelNo.Equals(hotelNo))
                {
                    Datacontroller.getInstance().HotelList.Remove(hotel);
                    break;
                }
                Console.WriteLine("Hotel {0} was deleted!",hotelNo);
            }
        }
        //
        // private static void Update()
        // {
        //     Console.WriteLine("Enter hotel's ID need to change:");
        //     string hotelNo = Console.ReadLine();
        //     foreach (Hotel hotel in Datacontroller.getInstance().HotelList)
        //     {
        //         if (hotel.HotelNo.Equals(hotelNo))
        //         {
        //             Hotel tmp = null;
        //             tmp.Input();
        //             Insert(tmp, hotellist.indexof(hotel));
        //             Hotel.remove(hotel);
        //         }
        //     }
        // }
        private static void FindRoomAvailable()
        {
            Console.WriteLine("Enter check in day (yyyy-MM-dd HH:mm:ss): ");
            DateTime checkIn = Utility.ConvertStringToDateTime(Console.ReadLine());

            Console.WriteLine("Enter check out day (yyyy-MM-dd HH:mm:ss): ");
            DateTime checkOut = Utility.ConvertStringToDateTime(Console.ReadLine());

            //Book -> CheckIn (checkIn & checkOut) || CheckOut (checkIn & checkOut)
            List<Booking> bookList = new List<Booking>();
            foreach (Booking booking in Datacontroller.getInstance().BookingList)
            {
                if (booking.CheckIn >= checkIn && booking.CheckIn <= checkOut)
                {
                    bookList.Add(booking);
                }
                else if (booking.CheckOut >= checkIn && booking.CheckOut <= checkOut)
                {
                    bookList.Add(booking);
                }
            }                    

            //Hien thi danh sach phong con trong:
            foreach (Hotel hotel in Datacontroller.getInstance().HotelList)
            {
                hotel.ShowRoomAvailable(bookList);
            }
        }   
        
        private static void SearchCustomerByCMNTD()
        {
            Console.WriteLine("Enter Customer's ID to find: ");
            string cmntd = Console.ReadLine();

            List<Hotel> list = new List<Hotel>();

            foreach (Booking booking in Datacontroller.getInstance().BookingList)
            {
                if (booking.CMTND == cmntd)
                {
                    Hotel hotel = Datacontroller.getInstance().FindHotel(booking.HotelNo);
                    if (hotel != null && !list.Contains(hotel))
                    {
                        list.Add(hotel);
                    }
                }
            }

            Console.WriteLine("List of hotels the customer has stayed at: ");
            foreach (Hotel hotel in list)
            {
                hotel.Display();
            }
        }
        
        private static void CalculateProfit()
        {
            foreach (Hotel hotel in Datacontroller.getInstance().HotelList)
            {
                int profit = hotel.CalculateProfit(Datacontroller.getInstance().BookingList);
                Console.WriteLine("Hotel's name: {0}, Hotel's ID: {1}, " +
                                  "Hotel's profit: {2}", hotel.Name, hotel.HotelNo, profit);
            }
        }
        
        private static void InputBooking()
        {
            Console.WriteLine("Enter booking infomation: ");
            Booking booking = new Booking();
            booking.Input();

            Datacontroller.getInstance().BookingList.Add(booking);
        }
        
        private static void DisplayHotel()
        {
            // Console.WriteLine("Hotel's Infomation:");
            foreach (Hotel hotel in Datacontroller.getInstance().HotelList)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("Hotel's Infomation:");
                hotel.DisplayAll();
            }
        }
        
        private static void InputHotel()
        {
            Console.WriteLine("Enter number of hotel you want to add:  ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Hotel hotel = new Hotel();
                hotel.Input();

                Datacontroller.getInstance().HotelList.Add(hotel);
            }
        }
        
        static void ShowMenu()
        {
            Console.WriteLine("1. Enter hotel's information");
            Console.WriteLine("2. Show hotel's information");
            Console.WriteLine("3. Book room");
            Console.WriteLine("4. Find available room");
            Console.WriteLine("5. Show hotel's profit");
            Console.WriteLine("6. Find customer's information");
            Console.WriteLine("7. Update hotel");
            Console.WriteLine("8. Delete hotel");
            Console.WriteLine("9. Exit the program");
            Console.WriteLine("Choose option ");
        }
    }
}