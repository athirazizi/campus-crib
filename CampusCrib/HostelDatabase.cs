﻿using System;
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
            // Create required tables
            try
            {
                DatabaseConnection = new SQLiteConnection(
                    DBConnection.DatabasePath, DBConnection.flags);
                DatabaseConnection.CreateTable<Hostel>();
                DatabaseConnection.CreateTable<User>();
                DatabaseConnection.CreateTable<Booking>();
                CurrentState = "Tables";
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

        public User CheckLogin(string username, string password)
        {
            var exists = DatabaseConnection.Table<User>()
                 .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();

            if (exists != null)
            {
                return exists;
            }
            else return null;
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

            var userBookings = DatabaseConnection.Table<Booking>().Where(b => b.BookingUser == globalref.currentUser.Username);
            bookings = new ObservableCollection<Booking>(userBookings.ToList());

            return bookings;
        }

        public Booking GetBookingByID(int bookingid)
        {
            var booking = DatabaseConnection.Table<Booking>()
                .Where(b => b.BookingID == bookingid)
                .FirstOrDefault();
            return booking;
        }


        public int UpdateBooking(Booking booking)
        {
            var updatestatus= DatabaseConnection.Update(booking);
            return updatestatus;
        }


        public int DeleteBooking(Booking booking)
        {
            var delstatus = DatabaseConnection.Delete(booking);
            return delstatus;
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