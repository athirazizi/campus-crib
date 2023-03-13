using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CampusCrib
{
    
    public class AllHostelsVM : INotifyPropertyChanged
    {
        HostelDatabase newDBInstance;

        public AllHostelsVM()
        {
            newDBInstance = new HostelDatabase();

            Hostel newHostel = new Hostel();
            newHostel.Name = "Hotel 0";
            newHostel.Description = "Hotel 0 Description";

            AllHostels = newDBInstance.GetAllHostel();
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
