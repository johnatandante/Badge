using System;
using System.Linq;
using System.Windows;
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
            
            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                LogEntry entry = new LogEntry {
                    Id = db.Entries.Count() + 1,
                    EntryTypeEnum = LogEntryDataService.GetLastType() == EntryType.In ? EntryType.Out : EntryType.In,
                    Time = DateTime.Now,
                };

                db.Entries.InsertOnSubmit(entry);
                BadgeState.Current.Entries.Add(entry);

                db.SubmitChanges();

                MessageBox.Show(string.Format("Event {0} logged at {1}", entry.EntryTypeEnum, entry.Time.ToString()), "Info", MessageBoxButton.OK);
            }

            

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            BadgeDataService.SetNavigationService(this.NavigationService);
            BadgeDataService.LoadLogData();

            // LogList.ItemsSource = BadgeState.Current.ReportLogs;
            // ReportList.ItemsSource = BadgeState.Current.Entries;
        }

    }
}