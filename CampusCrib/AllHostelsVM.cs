using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
                Description = "Bateman desc",
                Image0 = "ic_launcher"
            });

            source.Add(new Hostel
            {
                Name = "Harris House",
                Description = "Harris desc",
                Image0 = "ic_launcher"
            });

            source.Add(new Hostel
            {
                Name = "Caine House",
                Description = "Caine desc",
                Image0 = "ic_launcher"
            });

            source.Add(new Hostel
            {
                Name = "Paulley House",
                Description = "Paulley desc",
                Image0 = "ic_launcher"
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
