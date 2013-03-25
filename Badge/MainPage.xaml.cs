using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Badge.Database;
using Badge.Enum;
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


        private void LogEntryButton_Tap(object sender, System.Windows.Input.GestureEventArgs e) {

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {
                LogEntry entry = new LogEntry {
                    Id = db.Entries.Count() + 1,
                    EntryTypeEnum = LogEntry.GetLastType() == EntryType.In ? EntryType.Out : EntryType.In,
                    Time = DateTime.Now,
                };

                db.Entries.InsertOnSubmit(entry);
                BadgeState.Current.Entries.Add(entry);

                db.SubmitChanges();

                MessageBox.Show(string.Format("Azione {0} alle {1}", entry.EntryTypeEnum, entry.Time.ToString()), "Info", MessageBoxButton.OK);
            }

            

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            BadgeState.Current.LoadState();

            LogList.ItemsSource = BadgeState.Current.ReportLogs;
            ReportList.ItemsSource = BadgeState.Current.Entries;
        }

    }
}