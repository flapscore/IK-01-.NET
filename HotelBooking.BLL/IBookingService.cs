using System;
using System.Collections.Generic;
using HotelBooking.DAL;

namespace HotelBooking.BLL
{
    public interface IBookingService
    {
        bool CreateBooking(int roomId, DateTime start, DateTime end);
        bool CancelBooking(int bookingId);

        
        bool UpdateBooking(int bookingId, DateTime newStart, DateTime newEnd);
        Booking GetBooking(int bookingId);
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetBookingsForRoom(int roomId);
    }
}






