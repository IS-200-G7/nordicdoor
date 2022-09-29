using System.Configuration;
using MySqlConnector;

namespace PDSA_System.Client
{
    public class Helper : IDisposable
    {
        public MySqlConnection Connection { get; }

        public Helper(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();

    }
}