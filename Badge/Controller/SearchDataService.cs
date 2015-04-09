using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using Badge.Context;

namespace Badge.Controller {
    public class SearchDataService {

        public static void LoadLogData() {
            ReportLogDataService.LoadEntries();
            ReportLogDataService.LoadReportLogs();
        }

    }
}
