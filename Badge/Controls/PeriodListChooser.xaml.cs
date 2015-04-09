using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Badge.Context;
using Badge.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Badge.Controls {
    public partial class PeriodListChooser : UserControl {
        public PeriodListChooser() {
            InitializeComponent();
        }

        private void OnPeriodChanged(object sender, SelectionChangedEventArgs e) {
            if ((sender as ListPicker).SelectedItem is SupportedPeriod) {
                BadgeState.Current.Period = (sender as ListPicker).SelectedItem as SupportedPeriod;

            }

        }
    }
}
