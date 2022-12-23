using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// using System.Threading.Tasks;
using Asm2._2_Hotel.Models;
namespace Asm2._2_Hotel.Models
{
    public class DeleteHotel
    {
        public DeleteHotel(String hotelId)
        {
            foreach(Hotel hotel in Datacontroller.getInstance().HotelList)
            {
                if (hotelId.Equals(hotel.HotelNo))
                {
                    Datacontroller.getInstance().HotelList.Remove(hotel);
                }
            }
        }
    }
}