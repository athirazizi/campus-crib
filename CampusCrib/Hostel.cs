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
    }
}
