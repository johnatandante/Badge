using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Badge.Context;
using Badge.Database;
using Badge.Model;

namespace Badge.Controller {
    public class ReportLogDataService {

        public static List<ReportLog> ReadAll(SupportedPeriod period) {
            var list = new List<ReportLog>();

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {

                var entrylistIn = (from entry in db.Entries
                                   where entry.EntryTypeEnum == Model.EntryType.In && entry.Time >= period.From && entry.Time <= period.To
                                   orderby entry.Time
                                   select entry);
                var entrylistOut = (from entry in db.Entries
                                    where entry.EntryTypeEnum == Model.EntryType.Out && entry.Time >= period.From && entry.Time <= period.To
                                    orderby entry.Time
                                    select entry);

                foreach (var item in entrylistIn) {
                    list.Add(new ReportLog(item,
                                            entrylistOut.FirstOrDefault(log => log.Time > item.Time)));
                }

            }

            return list;
        }

        internal static void LoadEntries() {
            SearchState.Current.Entries = new  ObservableCollection<LogEntry>(LogEntryDataService.ReadAll(BadgeState.Current.Period));
        }

        internal static void LoadReportLogs() {
            SearchState.Current.ReportLogs = new ObservableCollection<ReportLog>(ReportLogDataService.ReadAll(BadgeState.Current.Period));
        }
    }
}
