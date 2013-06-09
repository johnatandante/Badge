using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Badge.Context;
using Badge.Model;

namespace Badge.Controller {
    public class GraphLogDataService {

        static SupportedPeriod[] CustomPeriods = new SupportedPeriod[] { 
            new SupportedPeriod() { Period= PeriodType.LastWeek },
            new SupportedPeriod() { Period= PeriodType.LastMonth },
            new SupportedPeriod() { Period= PeriodType.Last2Months },
            new SupportedPeriod() { Period= PeriodType.Last6Months },
            new SupportedPeriod() { Period= PeriodType.LastYear },
            new SupportedPeriod() { Period= PeriodType.All },
        };

        private static IEnumerable<ChartItemDataModel> GetGraphItemData(IEnumerable<ReportLog> reportLogs, EntryType filterType, PeriodType period = PeriodType.All) {
            var itemData = new List<ChartItemDataModel>();
            foreach (var reportLog in reportLogs) {
                if (reportLog.TimeIn == string.Empty ||
                    reportLog.TimeOut == string.Empty)
                    continue;

                itemData.Add(new ChartItemDataModel(reportLog.DateLog,
                                                    period,
                                                    filterType == EntryType.In ? reportLog.TimeIn 
                                                                               : reportLog.TimeOut)
                );
            }

            return itemData;
        }

        public static void LoadGraphData(bool useCache = false) {
            var period = BadgeState.Current.Period;
            if(!useCache)
                BadgeState.Current.ReportLogs = ReportLogDataService.ReadAll(period);

            BadgeState.Current.ChartDataIn = new ObservableCollection<ChartItemDataModel>(GraphLogDataService.GetGraphItemData(BadgeState.Current.ReportLogs, EntryType.In, period.Period));
            BadgeState.Current.ChartDataOut = new ObservableCollection<ChartItemDataModel>(GraphLogDataService.GetGraphItemData(BadgeState.Current.ReportLogs, EntryType.Out, period.Period));

        }

        public static void LoadSupportedPeriods() {
            BadgeState.Current.Periods = new ObservableCollection<SupportedPeriod>(CustomPeriods);            
        }

    }
}
