using System.Data;

namespace Mgi.Framework.Core
{
    public class ConnectionManager
    {
        public static string MasterConnectionString { get; set; }
        public static string SlaveConnectionString { get; set; }
        public static IDbConnection OpenMaster()
        {
            var connection = new Npgsql.NpgsqlConnection(MasterConnectionString);
            connection.Open();
            return connection;
        }
        public static IDbConnection OpenSlave()
        {
            var connection = new Npgsql.NpgsqlConnection(SlaveConnectionString);
            connection.Open();
            return connection;
        }
    }
}
