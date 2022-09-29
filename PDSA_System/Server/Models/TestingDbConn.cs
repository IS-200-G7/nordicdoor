using System;
using PDSA_System.Client;

namespace PDSA_System.Server.Models
{
    /*
     Denne klassen er for å teste din egen tilkobling til Databasen.
     */
    public class TestingDbConn
    {

        public void TestConn()
        {
            /*
             Endre din connectionString her.
             */
            using var connector = new DbHelper("server=localhost;user=root;database=NordicDoor;port=3306;password=PASSWORD");

            try
            {
                Console.WriteLine("Connecting to Server...");
                connector.Connection.Open();                    // tester connection

            }
            catch (Exception ex)                                // Dersom Open() kaster en error blir den fanget.
            {
                Console.WriteLine(ex.ToString());
            }
            connector.Connection.Close();                       // Dersom ingen error blir kastet closer vi connection og Skriver Done.
            Console.WriteLine("Done.");


        }
    }
}

