using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Navigation;
using Badge.Model;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class SearchState : BaseState {

        static SearchState istance = null;

        public static SearchState Current {
            get {
                if (istance == null)
                    istance = new SearchState();

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

        ICollection<LogEntry> entries = new ObservableCollection<LogEntry>();
        public ObservableCollection<LogEntry> Entries {
            get { return entries as ObservableCollection<LogEntry>; }
            set {
                entries = value;
                NotifyPropertyChanged("Entries");
            }
        }

        ICollection<ReportLog> reportLogs = new ObservableCollection<ReportLog>();
        public ObservableCollection<ReportLog> ReportLogs {
            get { return reportLogs as ObservableCollection<ReportLog>; }
            set {
                reportLogs = value;
                NotifyPropertyChanged("ReportLogs");
            }
        }

    }
}
