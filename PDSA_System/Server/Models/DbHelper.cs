using System.Configuration;
using MySql.Data.MySqlClient;

namespace PDSA_System.Client
{
    /**
     * Klasse "Helper" bruker interfasen IDisposable som lover å ha en Dispose() metode.
     * Bruker Nuget-Package MySql for å tilkoble seg databasen gjennom en tilkoblingsstreng.
     */
    public class DbHelper : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DbHelper(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();

    }
}