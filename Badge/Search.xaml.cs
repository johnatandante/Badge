using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Badge.Context;
using Badge.Controller;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Badge {
    public partial class Search : PhoneApplicationPage {
        public Search() {
            InitializeComponent();
            SearchDataService.LoadLogData();

            DataContext = SearchState.Current;

        }

        private void ReportListSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.AddedItems.Count == 0)
                return;

        }
    }
}