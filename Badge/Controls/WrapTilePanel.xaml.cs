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
using Badge.UiControls.ViewItem;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Badge.Controls {
    public partial class WrapTilePanel : UserControl {
        public WrapTilePanel() {
            InitializeComponent();
        }

        private void MenuTileTap(object sender, System.Windows.Input.GestureEventArgs e) {
            var itemView = sender as MenuTile;

            if (itemView.DataContext == null)
                return;
            var item = itemView.DataContext as Model.MenuItem;

            if (item.CallBackAction != null)
                item.CallBackAction();
            else
                BadgeDataService.GetNavigationService().Navigate(new Uri(string.Format("/{0}.xaml", item.Destination), UriKind.RelativeOrAbsolute));
        }

    }
}
