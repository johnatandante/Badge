using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Badge.Controller;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Badge {
    public partial class Search : PhoneApplicationPage {
        public Search() {
            InitializeComponent();
        }

        private void ReportListSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems.Count == 0)
                return;

            // .Navigate(new Uri(string.Format("/Trace.xaml?id={0}", item.Id), UriKind.RelativeOrAbsolute));
        }
    }
}