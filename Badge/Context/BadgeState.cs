using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Badge.Model;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class BadgeState : BaseState {

        static BadgeState istance = null;

        public static BadgeState Current {
            get {
                if (istance == null)
                    istance = new BadgeState();

                return istance;
            }
        }

        private SupportedPeriod period = new SupportedPeriod() { Period = PeriodType.LastWeek };
        public SupportedPeriod Period {
            get {
                return period;
            }
            set {
                period = value;
                NotifyPropertyChanged("Period");
            }
        }

        ObservableCollection<SupportedPeriod> periods = new ObservableCollection<SupportedPeriod>();
        public ObservableCollection<SupportedPeriod> Periods {
            get {
                return periods;
            }
            set {
                periods = value;
                NotifyPropertyChanged("Periods");
            }
        }

        ObservableCollection<ChartItemDataModel> chartDataIn = new ObservableCollection<ChartItemDataModel>();
        public ObservableCollection<ChartItemDataModel> ChartDataIn {
            get {
                return chartDataIn;
            }
            set {
                chartDataIn = value;
                NotifyPropertyChanged("ChartDataIn");
            }
        }

        ObservableCollection<ChartItemDataModel> chartDataOut = new ObservableCollection<ChartItemDataModel>();
        public ObservableCollection<ChartItemDataModel> ChartDataOut {
            get {
                return chartDataOut;
            }
            set {
                chartDataOut = value;
                NotifyPropertyChanged("ChartDataOut");
            }
        }

        ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> MenuItems {
            get {
                return menuItems;
            }
            set {
                menuItems = value;
                NotifyPropertyChanged("MenuItems");
            }
        }

        public BadgeState() {

        }

        public IList<ReportLog> ReportLogs { get; set; }

        public ReportLog LastLogItem {
            get {
                return ReportLogs == null ? null : ReportLogs.LastOrDefault();
            }
        }

    }
}
