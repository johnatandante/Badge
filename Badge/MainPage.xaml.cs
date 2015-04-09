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

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            BadgeDataService.SetNavigationService(this.NavigationService);
            BadgeDataService.LoadLogData();

            DataContext = BadgeState.Current;
            TileMenu.DataContext = BadgeState.Current;

        }

    }
}