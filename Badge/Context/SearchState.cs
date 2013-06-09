using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Navigation;
using Badge.Model;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class SearchState : BaseState {

        public static SearchState Current {
            get {
                if (istance == null)
                    istance = new SearchState();

                return istance as SearchState;
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
