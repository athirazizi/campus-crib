using SQLite;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Essentials;


namespace CampusCrib
{
    [Table("Hostel")]
    public class Hostel
    {
        [PrimaryKey, AutoIncrement]
        public int HID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoomDescription { get; set; }
        public string Image0 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }

        // Attribute used to calculate hostel distance from user's location

        // This does not work with sqlite db, swap to individual lat long values
        //public Location HostelLocation { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }


        // User should be able to sort collectionviews by these attributes
        public double Rating { get; set; }
        public double PricePerNight { get; set; }
        public double Distance { get; set; }


    }
}
