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

        public string Email { get; set; }
        // Phone No. as string to keep leading zeroes
        public string Phone { get; set; }

    }
}
