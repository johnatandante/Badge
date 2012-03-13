using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Badge.Model;

namespace Badge
{
    public class BadgeState
    {
        public static BadgeState Current = null;

        public List<LogEntry> Entries = new List<LogEntry>();
        public List<ReportLog> ReportLogs = new List<ReportLog>();

        public BadgeState()
        {
            Current = this;
        }

        public void LoadState(){

            Entries = LogEntry.ReadAll();
            ReportLogs = ReportLog.ReadAll();

        }


    }
}
