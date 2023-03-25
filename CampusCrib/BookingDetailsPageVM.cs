using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CampusCrib
{
    public class BookingDetailsPageVM : INotifyPropertyChanged
    {
        private HostelDatabase newDBInstance = new HostelDatabase();
        private App globalref = (App)Application.Current;

        public BookingDetailsPageVM()
        {
            LoadDetails();
        }

        private DateTime startdate;

        public DateTime StartDate
        {
            get
            {
                return startdate;
            }
            set
            {
                startdate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime enddate;

        public DateTime EndDate
        {
            get
            {
                return enddate;
            }
            set
            {
                enddate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private string hostelname;

        public string HostelName
        {
            get { return hostelname; }

            set
            {
                hostelname = value;
                OnPropertyChanged("HostelName");
            }
        }

        private string bookingphone;

        public string BookingPhone
        {
            get { return bookingphone; }

            set
            {
                bookingphone = value;
                OnPropertyChanged("BookingPhone");
            }
        }

        private string bookingemail;

        public string BookingEmail
        {
            get { return bookingemail; }

            set
            {
                bookingemail = value;
                OnPropertyChanged("BookingEmail");
            }
        }

        private double pricepernight;

        public double PricePerNight
        {
            get { return pricepernight; }

            set
            {
                pricepernight = value;
                OnPropertyChanged("PricePerDay");
            }
        }

        private double totalprice;

        public double TotalPrice
        {
            get { return totalprice; }

            set
            {
                totalprice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        private int duration;

        public int Duration
        {
            get { return duration; }

            set
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }

        private int bookingid { get; set; }

        public void LoadDetails()
        {
            var bid = globalref.selectedBooking.BookingID;
            var selectedBooking = newDBInstance.GetBookingByID(bid);

            bookingid = selectedBooking.BookingID;
            StartDate = selectedBooking.StartDate;
            EndDate = selectedBooking.EndDate;
            HostelName = selectedBooking.BookedHostelName;
            BookingPhone = selectedBooking.BookingPhone;
            BookingEmail = selectedBooking.BookingEmail;
            TotalPrice = selectedBooking.TotalPrice;
            Duration = selectedBooking.Duration;
            PricePerNight = selectedBooking.PricePerNight;
        }

        public void UpdateBooking()
        {
            if (EndDate > startdate && !(string.IsNullOrEmpty(BookingEmail)) && !(string.IsNullOrEmpty(BookingPhone)))
            {
                Booking updatedBooking = new Booking();

                updatedBooking.BookingID = bookingid;
                updatedBooking.StartDate = StartDate;
                updatedBooking.EndDate = EndDate;
                updatedBooking.BookingPhone = BookingPhone;
                updatedBooking.BookingEmail = BookingEmail;
                updatedBooking.BookingUser = globalref.currentUser.Username;
                updatedBooking.BookedHostelName = HostelName;
                int newDur = (EndDate - StartDate).Days;
                updatedBooking.Duration = newDur;
                updatedBooking.PricePerNight = PricePerNight;
                updatedBooking.TotalPrice = PricePerNight * newDur;

                newDBInstance = new HostelDatabase();
                newDBInstance.UpdateBooking(updatedBooking);

                Application.Current.MainPage.DisplayAlert("Success", "Booking has been updated.", "OK");

                // Take user back to home, bookings list will be refreshed
                Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Invalid dates or contact details are empty, please try again", "OK");
            }
        }

        public void DeleteBooking()
        {
            // Get the booking to delete
            var bookingid = globalref.selectedBooking.BookingID;
            var selectedBooking = newDBInstance.GetBookingByID(bookingid);

            newDBInstance = new HostelDatabase();
            newDBInstance.DeleteBooking(selectedBooking);

            Application.Current.MainPage.DisplayAlert("Success", "Booking has been deleted.", "OK");

            // Take user back to home, bookings list will be refreshed
            Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}