using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Badge.Context;
using Badge.Controller;
using Badge.Database;
using Badge.Model;
using Microsoft.Phone.Controls;

namespace Badge {
    public partial class MainPage : PhoneApplicationPage {
        // Constructor
        public MainPage() {
            InitializeComponent();

        }

        //private void LogEntryButton_Tap(object sender, Microsoft.Phone.Controls.GestureEventArgs e) {
        //    var entry = LogEntryDataService.LogNew();

        //    MessageBox.Show(string.Format("Event {0} logged at {1}", entry.EntryTypeEnum, entry.Time.ToString()), "Info", MessageBoxButton.OK);
        //    BadgeState.Current.Entries.Add(entry);

        //}

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            BadgeDataService.SetNavigationService(this.NavigationService);
            BadgeDataService.LoadLogData();

            DataContext = BadgeState.Current;
            TileMenu.DataContext = BadgeState.Current;

        }

        private void OnPeriodChanged(object sender, SelectionChangedEventArgs e) {
            if ((sender as ListPicker).SelectedItem is SupportedPeriod) {
                BadgeState.Current.Period = (sender as ListPicker).SelectedItem as SupportedPeriod;

            }

        }

    }
}