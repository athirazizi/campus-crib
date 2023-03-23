using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CampusCrib
{
    // Bookings made by the currently logged in user are displayed on this page
    public class BookingsPageVM : INotifyPropertyChanged
    {
        private HostelDatabase newDBInstance;

        public BookingsPageVM()
        {
            newDBInstance = new HostelDatabase();

            UserBookings = newDBInstance.GetBookingsByUser();
        }

        private ObservableCollection<Booking> userbookings;

        public ObservableCollection<Booking> UserBookings
        {
            get
            {
                return userbookings;
            }

            set
            {
                userbookings = value;
                OnPropertyChanged("UserBookings");
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