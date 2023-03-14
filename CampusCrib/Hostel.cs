using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusCrib
{
    [Table("Hostel")]
    public class Hostel
    {
        [PrimaryKey, AutoIncrement]
        public int HID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Image0 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
    }
}
