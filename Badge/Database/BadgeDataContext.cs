using Badge.Model;
using System.Data.Linq;

namespace Badge.Database
{
    public class BadgeDataContext : DataContext
    {

        public static string ConnectionString = "Data source=isostore:/LogEntry.sdf";

        public BadgeDataContext(string connectionString)
            : base(connectionString)
        {

        }

        public Table<LogEntry> Entries;
    }
}