using System;
using HotelBooking.BLL; 
using HotelBooking.DAL;

namespace HotelBooking.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new HotelBookingContext();
            var roomService = new RoomService(context);
            var bookingService = new BookingService(context);

            while (true)
            {
                Console.WriteLine("Welcome to the Hotel Booking System!");
                Console.WriteLine("1. View Rooms");
                Console.WriteLine("2. Make a Booking");
                Console.WriteLine("3. Cancel a Booking");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        return; 
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }
    }
}
