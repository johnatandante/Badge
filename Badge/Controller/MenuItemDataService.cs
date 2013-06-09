using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using Badge.Context;
using Badge.Model;

namespace Badge.Controller {
    public class MenuItemDataService {

        private static List<MenuItem> menuItemList = new List<MenuItem>() {
            { new MenuItem() { Name = "Quick Trace", ImagePath="/Toolkit.Content/ApplicationBar.Select.png", CallBackAction = LogNew} },
            { new MenuItem() { Name = "Trace", ImagePath="/Toolkit.Content/ApplicationBar.Select.png", Destination = "Trace" } },
            { new MenuItem() { Destination="Share", ImagePath="/Toolkit.Content/ApplicationBar.Share.png", Name="Share" } },
            { new MenuItem() { Destination="Search", ImagePath="/Toolkit.Content/ApplicationBar.Search.png", Name="Search" } },
            { new MenuItem() { Destination="YourLastAboutDialog;component/AboutPage", ImagePath="/Toolkit.Content/ApplicationBar.Check.png", Name="About & Rate" } },
            { new MenuItem() { Name = "Settings",  Destination = "Settings" } },
        };

        public static void LoadMenu() {
            BadgeState.Current.MenuItems = new ObservableCollection<MenuItem>(menuItemList);
        }

        private static void LogNew() {
            var entry = LogEntryDataService.LogNew();
            MessageBox.Show(string.Format("Event {0} logged at {1}", entry.EntryTypeEnum, entry.Time.ToString()), "Info", MessageBoxButton.OK);
            // BadgeState.Current.Entries.Add(entry);

            var last = BadgeState.Current.LastLogItem;
            if (last != null
                && last.DateLog.Date.Ticks == entry.Time.Date.Ticks
                && string.IsNullOrEmpty(last.DescriptionOut)) {
                last.DescriptionOut = entry.LogTypeText;
                last.TimeOut = entry.TimeText;
            } else {
                BadgeState.Current.ReportLogs.Add(new ReportLog(entry));
                GraphLogDataService.LoadGraphData(true);
            }

        }

        private static void NavigateTo(string destination) {
            BadgeDataService.GetNavigationService().Navigate(new Uri(string.Format("/{0}.xaml", destination), UriKind.RelativeOrAbsolute));

        }

    }
}
