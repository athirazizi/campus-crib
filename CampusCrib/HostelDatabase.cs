using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CampusCrib
{
    public class HostelDatabase
    {
        public string CurrentState;
        static SQLiteConnection DatabaseConnection;

        public HostelDatabase()
        {
            try
            {
                DatabaseConnection = new SQLiteConnection(
                    DBConnection.DatabasePath, DBConnection.flags);

                DatabaseConnection.CreateTable<Hostel>();

                CurrentState = "Database and table created";
            }
            catch (Exception ex)
            {
                CurrentState = ex.Message;
            }
        }

        // db utility functions

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
            hostels = new ObservableCollection<Hostel>(allHostels);
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
