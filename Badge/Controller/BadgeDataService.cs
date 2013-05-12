using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using Badge.Context;
using Badge.Model;

namespace Badge.Controller {
    public class BadgeDataService {

        public static void LoadLogData() {
            BadgeState state = BadgeState.Current;

            state.Entries = new ObservableCollection<LogEntry>(LogEntryDataService.ReadAll());
            state.ReportLogs = new ObservableCollection<ReportLog>(ReportLogDataService.ReadAll());

        }

        public static void SetNavigationService(NavigationService navi) {
            BadgeState.Current.NavigationService = navi;

        }


        public static NavigationService GetNavigationService() {
            return BadgeState.Current.NavigationService;
        }
    }
}
