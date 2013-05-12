using System;
using System.Linq;
using System.Collections.Generic;
using Badge.Database;
using Proattiva.Utils.Phone;

namespace Badge.Model {
    public class ReportLog {

        public DateTime DateLog { get; set; }
        protected LogEntry LogIn { get; set; }
        protected LogEntry LogOut { get; set; }

        public string DateLogString {
            get {
                return DateLog.ToShortDateString();
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
                return LogIn.Time.ToShortTimeString();
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
                return LogOut.Time.ToShortTimeString();
            }
            set {
                LogOut.Time = Convert.ToDateTime(value);
            }
        }

        public ReportLog() {
            LogIn = new LogEntry() { EntryTypeEnum = Model.EntryType.In };
            LogOut = new LogEntry() { EntryTypeEnum = Model.EntryType.Out };

            DateLog = LogIn.Time.Date;
        }

        public ReportLog(LogEntry logIn, LogEntry logOut) {
            LogIn = logIn;
            LogOut = logOut;

            DateLog = LogIn.Time.Date;

        }

    }

}
