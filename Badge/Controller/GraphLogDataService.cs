using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Badge.Context;
using Badge.Model;

namespace Badge.Controller {
    public class GraphLogDataService {

        private static IEnumerable<ChartItemDataModel> GetGraphItemData(EntryType filterType) {
            var reportLogs = ReportLogDataService.ReadAll();
            var itemData = new List<ChartItemDataModel>();
            foreach (var reportLog in reportLogs) {
                if (reportLog.TimeIn == string.Empty ||
                    reportLog.TimeOut == string.Empty)
                    continue;

                itemData.Add(new ChartItemDataModel(reportLog.DateLog,
                                                    filterType == EntryType.In ? reportLog.TimeIn 
                                                                               : reportLog.TimeOut)
                );
            }

            return itemData;
        }


        public static void LoadGraphData() {
            BadgeState.Current.ChartDataIn = new ObservableCollection<ChartItemDataModel>(GraphLogDataService.GetGraphItemData(EntryType.In));
            BadgeState.Current.ChartDataOut = new ObservableCollection<ChartItemDataModel>(GraphLogDataService.GetGraphItemData(EntryType.Out));

        }
    }
}
