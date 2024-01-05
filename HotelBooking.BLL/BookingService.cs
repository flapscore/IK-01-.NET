using System;
using System.Collections.Generic;
using System.Linq;
using HotelBooking.DAL; 

namespace HotelBooking.BLL
{
    public class BookingService : IBookingService
    {
        private readonly HotelBookingContext _context;

        public BookingService(HotelBookingContext context)
        {
            _context = context;
        }

        public bool CreateBooking(int roomId, DateTime start, DateTime end)
        {
            var overlappingBooking = _context.Bookings.Any(b => b.RoomId == roomId &&
                                                               b.DateFrom < end &&
                                                               b.DateTo > start);
            if (overlappingBooking)
            {
                return false; 
            }

            var booking = new Booking
            {
                RoomId = roomId,
                DateFrom = start,
                DateTo = end
            };
            _context.Bookings.Add(booking);
            return true;
        }

        public bool CancelBooking(int bookingId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking == null)
            {
                return false; 
            }

            _context.Bookings.Remove(booking);
            return true;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings;
        }

        public Booking GetBooking(int bookingId) 
        {
            return _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
        }

        public IEnumerable<Booking> GetBookingsForRoom(int roomId)
        {
            return _context.Bookings.Where(b => b.RoomId == roomId);
        }


        
        public bool UpdateBooking(int bookingId, DateTime newStart, DateTime newEnd)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking != null)
            {
                
                var overlap = _context.Bookings.Any(b => b.RoomId == booking.RoomId &&
                                                         b.BookingId != bookingId &&
                                                         b.DateFrom < newEnd &&
                                                         b.DateTo > newStart);
                if (overlap)
                {
                    return false; 
                }

                booking.DateFrom = newStart;
                booking.DateTo = newEnd;
                return true;
            }

            return false;
        }
    }
}
