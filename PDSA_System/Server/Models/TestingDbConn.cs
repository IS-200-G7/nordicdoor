namespace PDSA_System.Server.Models
{
    /*
     Denne klassen er for å teste din egen tilkobling til Databasen.
     */
    public class TestingDbConn
    {
        public void TestConn()
        {
            /* ConfigurationBuilder()
             * Brukes for å bygge nøkkel/verdi som baserer seg på config settinger som brukes i en applikasjon.
             * Legger til appsettings filen.
             * Dette lagres i et Json Objekt MyConfig.
             * Dette objektet kan hente verdier fra appsettings.json filen
             */
            var myConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connString = myConfig.GetValue<string>("ConnectionStrings:DefaultConnection");

            using var connector = new DbHelper(connString);

            try
            {
                Console.WriteLine("Connecting to Server...");
                connector.Connection.Open(); // tester connection
            }
            catch (Exception error) // Dersom Open() kaster en error blir den fanget.
            {
                Console.WriteLine("ErrorMessage:");
                Console.WriteLine(error.Message);
            }

            connector.Connection.Close(); // Dersom ingen error blir kastet closer vi connection og Skriver Done.
            Console.WriteLine("Done.");
        }
    }
}
