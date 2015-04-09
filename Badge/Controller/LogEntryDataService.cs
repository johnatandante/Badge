using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Badge.Database;
using Badge.Model;

namespace Badge.Controller {
    public class LogEntryDataService {

        public static List<LogEntry> ReadAll() {
            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                return db.Entries.ToList();
            }
        }

        public static List<LogEntry> ReadAll(SupportedPeriod period) {
            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                return (from entry in db.Entries
                        where entry.Time.Date >= period.From.Date && entry.Time.Date <= period.To.Date
                            orderby entry.Time
                            select entry).ToList();
            }
        }

        public static LogEntry Read(decimal id) {
            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                return db.Entries.FirstOrDefault(entry => entry.Id == id);
            }
        }

        public static EntryType GetLastType() {
            var last = default(LogEntry);
            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                last = (from entry in db.Entries
                                   orderby entry.Time descending
                                   select entry).FirstOrDefault();

            }

            return last != null ? last.EntryTypeEnum : EntryType.Out;
        }

        public static void Log(LogEntry[] logEntry) {
            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                foreach (var entry in logEntry) {
                    db.Entries.InsertOnSubmit(entry);
                }
                db.SubmitChanges();

            }
        }

        public static LogEntry LogNew() {
            var count = CountEntries();
            LogEntry entry = new LogEntry {
                // Id = count + 1,
                EntryTypeEnum = LogEntryDataService.GetLastType() == EntryType.In ? EntryType.Out : EntryType.In,
                Time = DateTime.Now,
            };

            Log(new LogEntry[] { entry });

            return entry;

        }

        private static int CountEntries() {
            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                return db.Entries.Count();
            }
        }

    }

}
