using System;
using System.ComponentModel;
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



        // Fetch the details of the chosen hostel
        public void LoadHostel()
        {
            var hid = globalref.selectedHostel.HID;
            var selectedHostel = newDBInstance.GetHostelByID(hid);

            // Pulling through name and price 


            Price = selectedHostel.PricePerNight;
            HostelName = selectedHostel.Name;

        }



        public void SaveBooking()
        {
            // Need to pull through the selected hostel object
            // (In order to set the bookedHostelName, and TotalPrice)

            Booking newbooking = new Booking();
            newbooking.StartDate = StartDate;
            newbooking.EndDate = EndDate;
            int dur = (EndDate - StartDate).Days;
            newbooking.Duration = dur;
            newbooking.BookingUser = globalref.currentUser;
            newbooking.BookedHostelName = HostelName;
            newbooking.TotalPrice = Price * dur;

            newDBInstance = new HostelDatabase();
            newDBInstance.AddBooking(newbooking);
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