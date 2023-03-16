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
                RoomDescription= "Bateman house has 42 single standard bedrooms. " +
                "Please bring your own bedding (to fit a single bed) and towels." +
                "Each room has a mini-fridge and a small vacuum cleaners.Shared bathroom facilities – 2 showers & wc’s per 7 students",
                Image0 = "bateman"
            });

            source.Add(new Hostel
            {
                Name = "Harris House",
                Description = "Ensuite Rooms",
                RoomDescription = "All rooms have a mini-cool and small vacuum cleaner. Please remember to bring your own bedding (to fit a single bed) and towels. " +
                "4 students share fully equipped kitchens.  Each student has a kitchen locker and an allocated drawer in a freezer.  Please bring your own pots & pans, crockery, knives & forks.",
                Image0 = "harris"
            });

            source.Add(new Hostel
            {
                Name = "Caine House",
                Description = "Self Contained,ensuite & standard rooms",
                RoomDescription = "These spacious rooms, which were refurbished in October 2016, have ensuite facilities and an open plan bedroom/kitchen. They feature double beds. These rooms are reserved for Postgraduate students." +
                "There are kitchens on each floor which are shared by 12 students.\r\n\r\nStudents staying in the ensuite and standard rooms have a kitchen locker and an allocated drawer in a freezer.\r\n\r\nPlease bring your own pots & pans, crockery and knives & forks.",
                Image0 = "Caine"
            });

            source.Add(new Hostel
            {
                Name = "Paulley House",
                Description = "Standard Rooms *REFURBISHED 4FT BEDS*",
                RoomDescription = "Paulley House is located on the Verney Park campus, next to the Law School. It is self-catering accommodation. " +
                "The 42 standard rooms were refurbished in January 2019. They feature a small double bed as well as everything else you would expect to find – a desk, shelves, a chair, a wardrobe, a chest of drawers and a vanity unit. We even supply you with your own small mini-cool and vacuum cleaner.\r\n\r\n You will need to bring your own bedding and towels." +
                "There is a spacious kitchen on each floor, fully equipped with cookers, microwaves, kettles and toasters. The kitchens are shared by 14 students. Students have their own kitchen lockers and an allocated drawer in a freezer. You will need to bring your own pots and pans, crockery, knives and forks.",
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
