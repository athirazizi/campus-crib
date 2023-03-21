using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CampusCrib
{
    public static class DBConnection
    {
        // db declaration
        public const string DatabaseName = "HostelDatabase.db3";

        // db flags
        public const SQLite.SQLiteOpenFlags flags =
            SQLite.SQLiteOpenFlags.Create |   // db create
            SQLite.SQLiteOpenFlags.ReadWrite; // db read & write

        // db path
        public static string DatabasePath
        {
            get
            {
                var basePath =
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                return Path.Combine(basePath, DatabaseName);
            }
        }
    }
}