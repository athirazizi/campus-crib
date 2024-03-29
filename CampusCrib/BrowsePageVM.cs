﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;

namespace CampusCrib
{
    public class BrowsePageVM : INotifyPropertyChanged
    {


        // List used for searching and sorting
        private IList<Hostel> source;

        HostelDatabase newDBInstance;


        public List<string> SortOptionsList { get; set; }

        // Fixing the user's location to central London for now.
        private Location userLocation = new Location(51.509865, -0.118092);

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

        public BrowsePageVM()
        {
            SortOptionsList = GetSortOptions().ToList();
            sampleData();
        }

        private void sampleData()
        {
            Hostel hostel1 = new Hostel
            {
                Name = "Bateman House",
                Description = "Standard single rooms",
                Image0 = "img_bateman.jpg",
                Image1 = "img_hostel_interior_0.jpg",
                Image2 = "img_hostel_interior_1.jpg",
                Rating = 4.3,
                PricePerNight = 19,
                Latitude = 51.989440,
                Longitude = -0.978940
            };
            hostel1.Distance = calcDistance(hostel1);
            

            Hostel hostel2 = new Hostel
            {
                Name = "Harris House",
                Description = "Single ensuite rooms",
                Image0 = "img_harris.jpg",
                Image1 = "img_hostel_interior_0.jpg",
                Image2 = "img_hostel_interior_1.jpg",
                Rating = 4.5,
                PricePerNight = 20,
                Latitude = 51.989440, 
                Longitude = -0.978940
            };
            hostel2.Distance = calcDistance(hostel2);
            

            Hostel hostel3 = new Hostel
            {
                Name = "Caine House",
                Description = "Self contained, ensuite, & standard single rooms",
                Image0 = "img_caine.jpg",
                Image1 = "img_hostel_interior_0.jpg",
                Image2 = "img_hostel_interior_1.jpg",
                Rating = 3.9,
                PricePerNight = 29,
                Latitude = 51.994840, 
                Longitude = -0.980520
            };
            hostel3.Distance = calcDistance(hostel3);
           

            Hostel hostel4 = new Hostel
            {
                Name = "Paulley House",
                Description = "Standard Rooms *REFURBISHED 4FT BEDS*",
                Image0 = "img_paulley.jpg",
                Image1 = "img_hostel_interior_0.jpg",
                Image2 = "img_hostel_interior_1.jpg",
                Rating = 4.9,
                PricePerNight = 19,
                Latitude = 51.989440, 
                Longitude = -0.978940
            };
            hostel4.Distance = calcDistance(hostel4);


            newDBInstance = new HostelDatabase();


            // These only need to be added once:

            // if there is nothing in the table, add hostels to the table

            if (newDBInstance.GetAllHostel().Count() == 0)
            {
                newDBInstance.AddHostel(hostel1);
                newDBInstance.AddHostel(hostel2);
                newDBInstance.AddHostel(hostel3);
                newDBInstance.AddHostel(hostel4);
            }

            AllHostels = newDBInstance.GetAllHostel();
            source = newDBInstance.GetAllHostel().ToList(); // Used in searching and sorting
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
            var searchedList = from Hostel hostel in source
                               where
                              hostel.Name.ToLower().Contains(searchterm.ToLower()) ||
                              hostel.Description.ToLower().Contains(searchterm.ToLower())
                               select hostel;

            // set the returned collection to the filtered hostel list;
            ObservableCollection<Hostel> hostels = new ObservableCollection<Hostel>(searchedList.ToList());

            AllHostels = hostels;
        }



        //Function to get exact distanct between user location and hostel location. 
        private double calcDistance(Hostel hostel)
        {
            var hostellocation = new Location(hostel.Latitude, hostel.Longitude);

            double dist = Location.CalculateDistance(userLocation, hostellocation, DistanceUnits.Miles);
            dist = Math.Round(dist, 2);
            return dist;
        }


        // Sorting picker functions

        public List<string> GetSortOptions()
        {
            var sortoptions = new List<string>();
            {
                sortoptions.Add("Name A → Z");
                sortoptions.Add("Name Z → A");
                sortoptions.Add("Price Low → High");
                sortoptions.Add("Price High → Low");
                sortoptions.Add("Rating Low → High");
                sortoptions.Add("Rating High → Low");
                sortoptions.Add("Distance Closest → Furthest");
                sortoptions.Add("Distance Furthest → Closest");
            }
            return sortoptions;
        }

        // Sorting logic goes here. Use onpropertychanged

        private string selectedoption;

        public string SelectedOption
        {
            get { return selectedoption; }
            set
            {
                selectedoption = value;
                OnPropertyChanged("SelectedOption");
                Sort();
            }
        }

        // Sort with LINQ


        private void Sort()
        {
            if (SelectedOption == "Name A → Z")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderBy(x => x.Name).ToList());

                AllHostels = sortedList;
            }
            else if (SelectedOption == "Name Z → A")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderByDescending(x => x.Name).ToList());

                AllHostels = sortedList;
            }
            else if (SelectedOption == "Price Low → High")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderBy(x => x.PricePerNight).ToList());

                AllHostels = sortedList;
            }
            else if (SelectedOption == "Price High → Low")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderByDescending(x => x.PricePerNight).ToList());

                AllHostels = sortedList;
            }
            else if (SelectedOption == "Rating Low → High")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderBy(x => x.Rating).ToList());

                AllHostels = sortedList;
            }
            else if (SelectedOption == "Rating Low → High")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderByDescending(x => x.Rating).ToList());

                AllHostels = sortedList;
            }
            else if (SelectedOption == "Distance Closest → Furthest")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderBy(x => x.Distance).ToList());

                AllHostels = sortedList;
            }
            else if (SelectedOption == "Distance Furthest → Closest")
            {
                var sortedList = new ObservableCollection<Hostel>(source.OrderByDescending(x => x.Distance).ToList());

                AllHostels = sortedList;
            }
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