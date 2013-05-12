using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Badge.Database;
using Badge.Model;

namespace Badge.Controller {
    public class LogEntryDataService {

        public static List<LogEntry> ReadAll() {
            var list = default(List<LogEntry>);

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                list = db.Entries.ToList();

            }

            return list;
        }

        public static LogEntry Read(decimal id) {
            var item = default(LogEntry);

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                item = db.Entries.FirstOrDefault(entry => entry.Id == id);
            }

            return item;
        }

        public static EntryType GetLastType() {
            var last = default(LogEntry);

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                last = db.Entries.Last();

            }

            if (last == null)
                return EntryType.Out;

            return last.EntryTypeEnum;
        }
    }

}
