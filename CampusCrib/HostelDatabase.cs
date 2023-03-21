using System;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;

namespace CampusCrib
{
    public class HostelDatabase
    {
        public string CurrentState;
        private static SQLiteConnection DatabaseConnection;
        private App globalref = (App)Application.Current;

        public HostelDatabase()
        {
            // Create Hostel table
            try
            {
                DatabaseConnection = new SQLiteConnection(
                    DBConnection.DatabasePath, DBConnection.flags);
                DatabaseConnection.CreateTable<Hostel>();
                CurrentState = "Hostel table created";
            }
            catch (Exception ex)
            {
                CurrentState = ex.Message;
            }

            // Create User table
            try
            {
                DatabaseConnection = new SQLiteConnection(
                    DBConnection.DatabasePath, DBConnection.flags);
                DatabaseConnection.CreateTable<User>();

                CurrentState = "User table created";
            }
            catch (Exception ex)
            {
                CurrentState = ex.Message;
            }

            // Create Bookings table
            try
            {
                DatabaseConnection = new SQLiteConnection(
                    DBConnection.DatabasePath, DBConnection.flags);
                DatabaseConnection.CreateTable<Booking>();
                CurrentState = "Bookings table created";
            }
            catch (Exception ex)
            {
                CurrentState = ex.Message;
            }
        }

        // DB utility functions:


        // User table utility functions
        public int AddUser(User user)
        {
            int insertStatus = 0;
            insertStatus = DatabaseConnection.Insert(user);
            return insertStatus;
        }

        public bool CheckLogin(string username, string password)
        {
            var exists = DatabaseConnection.Table<User>()
                 .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();

            if (exists != null)
            {
                return true;
            }
            else return false;
        }

        // Booking table util functions
        public int AddBooking(Booking booking)
        {
            int insertStatus = 0;
            insertStatus = DatabaseConnection.Insert(booking);
            return insertStatus;
        }

        public ObservableCollection<Booking> GetBookingsByUser()
        {
            ObservableCollection<Booking> bookings;

            var userBookings = DatabaseConnection.Table<Booking>().Where(b => b.BookingUser == globalref.currentUser);
            bookings = new ObservableCollection<Booking>(userBookings.ToList());

            return bookings;
        }

        // Hostel table utility functions
        public int AddHostel(Hostel hostel)
        {
            int insertStatus = 0;
            insertStatus = DatabaseConnection.Insert(hostel);
            return insertStatus;
        }

        public int DeleteHostel(Hostel hostel)
        {
            int deleteStatus = 0;
            deleteStatus = DatabaseConnection.Delete(hostel);
            return deleteStatus;
        }

        public int UpdateHostel(Hostel hostel)
        {
            int updateStatus = 0;
            updateStatus = DatabaseConnection.Update(hostel);
            return updateStatus;
        }

        public ObservableCollection<Hostel> GetAllHostel()
        {
            ObservableCollection<Hostel> hostels;

            var allHostels = DatabaseConnection.Table<Hostel>();
            hostels = new ObservableCollection<Hostel>(allHostels.ToList());
            return hostels;
        }

        public Hostel GetHostelByID(int hid)
        {
            var hostel = DatabaseConnection.Table<Hostel>()
                .Where(host => host.HID == hid)
                .FirstOrDefault();
            return hostel;
        }
    }
}