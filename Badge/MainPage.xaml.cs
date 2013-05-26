using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Badge.Context;
using Badge.Controller;
using Badge.Database;
using Badge.Model;
using Microsoft.Phone.Controls;

namespace Badge
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void LogEntryButton_Tap(object sender, Microsoft.Phone.Controls.GestureEventArgs e) {
            var entry = LogEntryDataService.LogNew();

            MessageBox.Show(string.Format("Event {0} logged at {1}", entry.EntryTypeEnum, entry.Time.ToString()), "Info", MessageBoxButton.OK);
            BadgeState.Current.Entries.Add(entry);

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            BadgeDataService.SetNavigationService(this.NavigationService);
            BadgeDataService.LoadLogData();

            this.DataContext = BadgeState.Current;
            TileMenu.DataContext = BadgeState.Current;

        }

        private void ReportListSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems.Count == 0)
                return;

            var item = e.AddedItems[0] as Model.LogEntry;
            BadgeDataService.GetNavigationService().Navigate(new Uri(string.Format("/Trace.xaml?id={0}", item.Id), UriKind.RelativeOrAbsolute));
        }

    }
}