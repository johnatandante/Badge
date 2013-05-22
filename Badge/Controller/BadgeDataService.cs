using System;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Badge.Context;
using Badge.Model;

namespace Badge.Controller {
    public class BadgeDataService {

        private static LogEntry logEntry1 = new LogEntry() { EntryTypeEnum = EntryType.In, Id = 999999M, Time = DateTime.Now };
        private static LogEntry logEntry2 = new LogEntry() { EntryTypeEnum = EntryType.Out, Id = 999998M, Time = DateTime.Now };

        public static void LoadLogData() {

            var entry = new ObservableCollection<LogEntry>(LogEntryDataService.ReadAll());
            entry.Add(logEntry1);
            entry.Add(logEntry2);
            entry.Add(new LogEntry() { EntryTypeEnum = EntryType.In, Id = 999997M, Time = DateTime.Now });
            BadgeState.Current.Entries = entry;

            var reports = new ObservableCollection<ReportLog>(ReportLogDataService.ReadAll());
            reports.Add(new ReportLog(logEntry1, logEntry2));
            BadgeState.Current.ReportLogs = reports;

        }

        public static void SetNavigationService(NavigationService navi) {
            BadgeState.Current.NavigationService = navi;
        }

        public static NavigationService GetNavigationService() {
            return BadgeState.Current.NavigationService;
        }

    }
}