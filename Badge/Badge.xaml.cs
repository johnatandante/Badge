using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Badge.Database;
using Badge.Model;
using Badge.Enum;
using Microsoft.Phone.Controls;
using System.Windows.Input;
using System.Windows;

namespace Badge
{
    public partial class Badge : PhoneApplicationPage
    {

        BadgeState badgeState = new BadgeState();

        public Badge()
        {
            InitializeComponent();
            
            LogList.ItemsSource = BadgeState.Current.ReportLogs;
            ReportList.ItemsSource = BadgeState.Current.Entries;

        }

        private void LogEntryButton_Tap(object sender, GestureEventArgs e)
        {

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString))
            {
                LogEntry entries = new LogEntry
                {
                    Id = db.Entries.Count() + 1,
                    EntryTypeEnum = LogEntry.GetLastType() == EntryType.In ? EntryType.Out : EntryType.In,
                    Time = DateTime.Now,
                };

                db.Entries.InsertOnSubmit(entries);
                db.SubmitChanges();

                MessageBox.Show(string.Format("Azione {0} alle {1}", entries.EntryTypeEnum, entries.Time.ToString()), "Info", MessageBoxButton.OK);
            }

        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            BadgeState.Current.LoadState();
        }

    }
}