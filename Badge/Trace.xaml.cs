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

    }
}