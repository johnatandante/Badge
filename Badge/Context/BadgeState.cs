using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Navigation;
using Badge.Model;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class BadgeState : PropertyChangedBaseClass {

        private static BadgeState istance;
        public static BadgeState Current {
            get {
                if (istance == null)
                    istance = new BadgeState();

                return istance;
            }
        }

        ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>() {
            { new MenuItem() { Name = "Trace", ImagePath="/Toolkit.Content/ApplicationBar.Select.png", Destination = "Trace" } },
            { new MenuItem() { Destination="Share", ImagePath="/Toolkit.Content/ApplicationBar.Share.png", Name="Share" } },
            { new MenuItem() { Destination="Search", ImagePath="/Toolkit.Content/ApplicationBar.Search.png", Name="Search" } },
            { new MenuItem() { Destination="Rate", ImagePath="/Toolkit.Content/ApplicationBar.Check.png", Name="Rate" } },
            { new MenuItem() { Name = "Settings",  Destination = "Settings" } }
        };

        public ObservableCollection<MenuItem> MenuItems {
            get {
                return menuItems;
            }
            set {
                menuItems = value;
                NotifyPropertyChanged("MenuItems");
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


        public BadgeState() {

        }


        public ReportLog LastLogItem {
            get {
                return ReportLogs.Last();
            }
        }

        public NavigationService NavigationService { get; set; }

    }
}
