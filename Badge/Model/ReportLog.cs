﻿using System;
using System.Linq;
using System.Collections.Generic;
using Badge.Database;
using Proattiva.Utils.Phone;

namespace Badge.Model {
    public class ReportLog {

        public DateTime DateLog = DateTime.Now;

        protected LogEntry LogIn = new LogEntry();
        protected LogEntry LogOut = new LogEntry();

        public string DateLogString {
            get {
                return DateLog == DateTime.MinValue ? string.Empty : DateLog.ToShortDateString();
            }
            set {
                DateLog = Convert.ToDateTime(value);
            }
        }

        public string DescriptionIn {
            get {
                return LogIn.EntryTypeEnum.ToString();
            }
            set {
                LogIn.EntryTypeEnum = (EntryType)Enum.Parse(typeof(EntryType), value, false);
            }
        }

        public string TimeIn {
            get {
                return LogIn.Time.Ticks == DateTime.MinValue.Ticks ? string.Empty : LogIn.Time.ToShortTimeString();
            }
            set {
                LogIn.Time = Convert.ToDateTime(value);
            }
        }

        public string DescriptionOut {
            get {
                return LogOut.EntryTypeEnum.ToString();
            }
            set {
                LogOut.EntryTypeEnum = (EntryType)Enum.Parse(typeof(EntryType), value, false);
            }
        }

        public string TimeOut {
            get {
                return LogOut.Time.Ticks == DateTime.MinValue.Ticks ? string.Empty : LogOut.Time.ToShortTimeString();
            }
            set {
                LogOut.Time = Convert.ToDateTime(value);
            }
        }

        public ReportLog() {

        }

        public ReportLog(LogEntry logIn, LogEntry logOut = null) {
            LogIn = logIn ?? LogEntry.NewLogIn();
            LogOut = logOut ?? LogEntry.NewLogOut();

            DateLog = logIn.Time.Date;

        }

        public void CheckIn(LogEntry logIn) {
            LogIn = logIn;
        }

        public void CheckOut(LogEntry logOut) {
            LogOut = logOut;

        }

    }

}
