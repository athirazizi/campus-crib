using System;

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

        public int Duration { get; set; }

        public int TotalPrice { get; set; }


        // Track the date on which the booking was made for display on the 'mybookingspage'
        public static DateTime CreatedTime = DateTime.Now;
        public string CreatedDate = CreatedTime.ToShortDateString();


        // Username of the user who placed the booking (get from currently logged in user)
        public string BookingUser { get; set; }
        public string BookedHostelName { get; set; }
    }
}