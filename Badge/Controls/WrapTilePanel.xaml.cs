using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Badge.Controller;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Badge.Controls {
    public partial class WrapTilePanel : UserControl {
        public WrapTilePanel() {
            InitializeComponent();
        }

        private void MenuItemSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (!(sender is ListBox))
                return;
            var listBoxControl = sender as ListBox;

            if (listBoxControl.SelectedItem == null)
                return;
            var item = listBoxControl.SelectedItem as Model.MenuItem;

            BadgeDataService.GetNavigationService().Navigate(new Uri(string.Format("/{0}.xaml", item.Destination), UriKind.RelativeOrAbsolute));

        }

    }
}
