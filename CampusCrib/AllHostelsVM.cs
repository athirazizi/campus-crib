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

            AllHostels = new ObservableCollection<Hostel>(source); //* COLLISION OF OVERRIDE WITH THE SEARCH FUNCTION*
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
             var filteredList= from Hostel source in AllHostels where 
                               source.Name.ToLower().Contains(searchterm.ToLower()) || 
                               source.Description.ToLower().Contains(searchterm.ToLower())
                               select source;

            AllHostels = new ObservableCollection<Hostel>(filteredList.ToList()); // * NEEDS TO BE OVERLOOKED , Cannot revert back to the original list after search*
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
