using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Badge.Context;
using Badge.Database;
using Badge.Model;

namespace Badge.Controller {
    public class ReportLogDataService {

        public static List<ReportLog> ReadAll() {

            var list = new List<ReportLog>();

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {

                var entrylistIn = (from entry in db.Entries
                                   where entry.EntryTypeEnum == Model.EntryType.In
                                   orderby entry.Time
                                   select entry);
                var entrylistOut = (from entry in db.Entries
                                    where entry.EntryTypeEnum == Model.EntryType.Out
                                    orderby entry.Time
                                    select entry);

                foreach (var item in entrylistIn) {
                    list.Add(new ReportLog(item,
                                            entrylistOut.FirstOrDefault(log => log.Time > item.Time)));
                }

            }

            return list;
        }

        //private static LogEntry logEntry1 = new LogEntry() { EntryTypeEnum = EntryType.In, Id = 999999M, Time = DateTime.Now };
        //private static LogEntry logEntry2 = new LogEntry() { EntryTypeEnum = EntryType.Out, Id = 999998M, Time = DateTime.Now };

        internal static void LoadEntries() {
            //var entry = new ObservableCollection<LogEntry>(LogEntryDataService.ReadAll());
            //entry.Add(logEntry1);
            //entry.Add(logEntry2);
            //entry.Add(new LogEntry() { EntryTypeEnum = EntryType.In, Id = 999997M, Time = DateTime.Now });
            //BadgeState.Current.Entries = entry;
            BadgeState.Current.Entries = new ObservableCollection<LogEntry>(LogEntryDataService.ReadAll());
        }

        internal static void LoadReportLogs() {
            //var reports = new ObservableCollection<ReportLog>(ReportLogDataService.ReadAll());
            //reports.Add(new ReportLog(logEntry1, logEntry2));
            // BadgeState.Current.ReportLogs = reports;
            BadgeState.Current.ReportLogs = new ObservableCollection<ReportLog>(ReportLogDataService.ReadAll());
        }
    }
}
