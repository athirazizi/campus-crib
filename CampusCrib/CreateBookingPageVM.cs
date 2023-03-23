using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using Xamarin.Forms;

namespace CampusCrib
{
    public class CreateBookingPageVM : INotifyPropertyChanged
    {
        private App globalref = (App)Application.Current;

        private HostelDatabase newDBInstance = new HostelDatabase();


        public CreateBookingPageVM()
        {
            LoadHostel();
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


        private double price;

        public double Price
        {
            get { return price; }
            set { price = value;
                OnPropertyChanged("Price");
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




        // Fetch the details of the chosen hostel as well as some details of the User
        public void LoadHostel()
        {
            var hid = globalref.selectedHostel.HID;
            var selectedHostel = newDBInstance.GetHostelByID(hid);


            Price = selectedHostel.PricePerNight;
            HostelName = selectedHostel.Name;
            BookingPhone = globalref.currentUser.Phone;
            BookingEmail = globalref.currentUser.Email;

        }



        public void SaveBooking()
        {
            // Need to pull through the selected hostel object and validate the user's choices on creation

            if (EndDate > startdate && BookingEmail != "" && BookingPhone != "") {
                Booking newbooking = new Booking();
                newbooking.StartDate = StartDate;
                newbooking.EndDate = EndDate;
                int dur = (EndDate - StartDate).Days;
                newbooking.Duration = dur;
                newbooking.BookingUser = globalref.currentUser.Username;
                newbooking.BookedHostelName = HostelName;
                newbooking.TotalPrice = Price * dur;
                newbooking.BookingEmail = BookingEmail;
                newbooking.BookingPhone = BookingPhone;
                newbooking.PricePerNight = globalref.selectedHostel.PricePerNight;

                newDBInstance = new HostelDatabase();
                newDBInstance.AddBooking(newbooking);

                Application.Current.MainPage.DisplayAlert("Success", "Booking has been created.", "OK");

                // Take user back to home, bookings list will be refreshed
                Application.Current.MainPage.Navigation.PushAsync(new MainPage());

            }

            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Dates or contact details are invalid, please try again", "OK");
            }


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