using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
namespace Asm2._2_Hotel.Models
{
    public class Datacontroller
    {
        public List<Customer> CustomerList { get; set; }
        public List<Hotel> HotelList { get; set; }
        public List<Booking> BookingList { get; set; }

        public static Datacontroller instance = null;

        private Datacontroller()
        {
            CustomerList = new List<Customer>();
            HotelList = new List<Hotel>();
            BookingList = new List<Booking>();
        }

        public static Datacontroller getInstance()
        {
            if (instance == null)
            {
                instance = new Datacontroller();
            }
            return instance;
        }

        public Hotel FindHotel(string hotelNo)
        {
            foreach (Hotel hotel in HotelList)
            {
                if (hotel.HotelNo == hotelNo)
                {
                    return hotel;
                }
            }
            return null;
        }
    }
}