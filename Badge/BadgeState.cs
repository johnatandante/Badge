using System.Linq;
using System.Collections.Generic;
using Badge.Model;
using System.Collections.ObjectModel;
using Proattiva.Utils.Phone;

namespace Badge
{
    public class BadgeState : PropertyChangedBaseClass
    {
        private static BadgeState istance;
        public static BadgeState Current {
            get{
                if(istance == null)
                    istance = new BadgeState();

                return istance;
            }
        }

        public ICollection<LogEntry> Entries = new ObservableCollection<LogEntry>();
        public ICollection<ReportLog> ReportLogs = new ObservableCollection<ReportLog>();

        public BadgeState()
        {
            LoadState();
        }

        public void LoadState(){

            Entries = LogEntry.ReadAll();
            ReportLogs = ReportLog.ReadAll();

        }

        public ReportLog LastLogItem {
            get {
                return ReportLogs.Last();
            }
        }


    }
}
