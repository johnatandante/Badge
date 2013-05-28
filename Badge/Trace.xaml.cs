using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Badge.Context;
using Badge.Controller;
using Badge.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Badge {
    public partial class Trace : PhoneApplicationPage {
        
        public Trace() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            var context = TraceState.GetNew();
            if (this.NavigationContext.QueryString.ContainsKey("id")) {
                var id = this.NavigationContext.QueryString["id"];
                GetContext(id);

            } 
            //else if (this.NavigationContext.QueryString.ContainsKey("shot")) {
            //    this.NavigationContext.QueryString.Remove("shot");
            //    cameraTask.Show();
            //}

            this.DataContext = context;
            base.OnNavigatedTo(e);
        }

        private TraceState GetContext(string idString) {
            var state = TraceState.GetNew();
            decimal id = 0M;
            if (decimal.TryParse(idString, out id)) {
                state.LogEntryItem = LogEntryDataService.Read(id);
                EntryTypeListBox.SelectedItem = state.LogEntryItem.EntryTypeEnum;

            }

            return state;
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            this.DataContext = TraceState.GetNew();
            
        }

        private void InsertLogIconButtonClick(object sender, EventArgs e) {
            var entry = (DataContext as TraceState).LogEntryItem;
            entry.EntryTypeEnum = (EntryType)EntryTypeListBox.SelectedItem;
            if (!DatePickerControl.Value.HasValue || !TimePickerControl.Value.HasValue)
                return;

            entry.Time = DatePickerControl.Value.Value.Date;
            entry.Time = entry.Time.AddMinutes(TimePickerControl.Value.Value.Minute);
            entry.Time = entry.Time.AddHours(TimePickerControl.Value.Value.Hour);

            LogEntryDataService.Log(new LogEntry[] {entry });
            MessageBox.Show(string.Format("Event {0} logged at {1}", entry.EntryTypeEnum, entry.Time.ToString()), "Info", MessageBoxButton.OK);
            BadgeDataService.GetNavigationService().GoBack();

        }

        private void CancelIconButtonClick(object sender, EventArgs e) {
            BadgeDataService.GetNavigationService().GoBack();

        }

        private void EntryTypeListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {

        }

    }
}