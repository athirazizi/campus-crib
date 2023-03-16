using System;
using System.Collections.Generic;
using System.Text;

namespace CampusCrib
{
    // Class used for individual storage of a booking
    // Object created when a user books with 'CreateBookingPage'
    // Bookings will be placed in database table / collectionview?

    public class Booking
    {
        // Two dates will need to be chosen with datepicker
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        
        // duration attribute? 


        // Username of the user who placed the booking (get from currently logged in user)
        public string BookingUser { get; set; }

        public Hostel bookedHostel { get; set; }
    }
}
