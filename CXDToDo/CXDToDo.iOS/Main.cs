using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using System.IO;
using SQLite;
using static CXDToDo.iOS.Application;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace CXDToDo.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        public class DatabaseConnection_iOS : IDatabaseConnection
        {
            public SQLiteConnection DBConnection()
            {
                //var dbName = "podDB.db3";
                //string personalFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                //string libraryFolder = Path.Combine(personalFolder, "Library"); 
                //var path = Path.Combine(libraryFolder, dbName);
                //return new SQLiteConnection(path);

                var sqliteFilename = "CXDToDoDB.db3";
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(libraryPath, sqliteFilename);
                // Create the connection
                var conn = new SQLite.SQLiteConnection(path);
                // Return the database connection
                return conn;
            }
        }
    }
}
