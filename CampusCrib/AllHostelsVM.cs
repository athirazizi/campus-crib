using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace CampusCrib
{
    
    public class AllHostelsVM : INotifyPropertyChanged
    {

        // How exactly is this working?

        // What is controlling the quantity of items appearing in the observable collection...

        HostelDatabase HostelDB = new HostelDatabase();

        public ObservableCollection<Hostel> HostelCollection { get; } = 
        new ObservableCollection<Hostel>();

        public AllHostelsVM()
        {
            Hostel newHostel= new Hostel();
            newHostel.Name = "testHostelName";
            newHostel.Description = "testHostelDesc";
            HostelDB.AddHostel(newHostel);

            List<Hostel> hostelList;

            using (var connection = new SQLiteConnection(DBConnection.DatabasePath, DBConnection.flags))
            {
                hostelList = connection.Query<Hostel>("SELECT * FROM Hostel");
                foreach (var record in hostelList)
                {
                    HostelCollection.Add(record);
                }
            }
        }

        private ObservableCollection<Hostel> allhostels;
        public ObservableCollection<Hostel> AllHostels
        {
            get
            {
                return allhostels;
            }
            set
            {
                allhostels = value;
                OnPropertyChanged("AllHostels");
            }
        }

        private string searchterm;
        public string SearchTerm
        {
            get
            {
                return searchterm;
            }
            set
            {
                searchterm = value;
                OnPropertyChanged("SearchTerm");
                Search();
            }
        }

        private void Search()
        {
 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
