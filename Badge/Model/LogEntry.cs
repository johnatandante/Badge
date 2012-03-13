using Badge.Enum;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using Badge.Database;

namespace Badge.Model
{
    [Table]
    public class LogEntry
    {

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public decimal Id { get; set; }

        [Column]
        public DateTime Time { get; set; }


        [Column]
        public EntryType EntryTypeEnum { get; set; }

        public string LogTypeText {
            get{
                return EntryTypeEnum.ToString();
            }
        }

        public string TimeText {
            get
            {
                return Time.ToString();
            }
        }


        public static List<LogEntry> ReadAll()
        {
            var list = default(List<LogEntry>);

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString))
            {
                list = db.Entries.ToList();
                
            }

            return list;
        }

        public static LogEntry Read(decimal id)
        {
            var item = default(LogEntry);

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString))
            {
                item = db.Entries.FirstOrDefault(entry => entry.Id == id);

            }

            return item;
        }

        public static EntryType GetLastType()
        {
            var last = default(LogEntry);

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString))
            {
                // last = db.Entries.Last();

            }

            if (last == null)
                return EntryType.Out;

            return last.EntryTypeEnum;
        }
    }
}
