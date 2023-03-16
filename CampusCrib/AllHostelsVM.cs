using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CampusCrib
{
    
    public class AllHostelsVM : INotifyPropertyChanged
    {
        readonly IList<Hostel> source;

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

        public AllHostelsVM()
        {
            source = new List<Hostel>();
            sampleData();
        }

        void sampleData()
        {
            source.Add(new Hostel
            {
                Name = "Bateman House",
                Description = "Standard Rooms",
                Image0 = "bateman"
            });

            source.Add(new Hostel
            {
                Name = "Harris House",
                Description = "Ensuite Rooms",
                Image0 = "harris"
            });

            source.Add(new Hostel
            {
                Name = "Caine House",
                Description = "Self Contained,ensuite & standard rooms",
                Image0 = "Caine"
            });

            source.Add(new Hostel
            {
                Name = "Paulley House",
                Description = "Standard Rooms *REFURBISHED 4FT BEDS*",
                Image0 = "paulley"
            });

            AllHostels = new ObservableCollection<Hostel>(source);
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
             var filteredList= from Hostel hostel in source where 
                               hostel.Name.ToLower().Contains(searchterm.ToLower()) || 
                               hostel.Description.ToLower().Contains(searchterm.ToLower())
                               select hostel;

            ObservableCollection<Hostel> hostels = new ObservableCollection<Hostel>(filteredList.ToList());// set the returned collection to listviewAllCustomers= customers;

            AllHostels = hostels;
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
