using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CampusCrib
{

    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
