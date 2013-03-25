using System;
using System.Linq;
using System.Collections.Generic;
using Badge.Database;
using Proattiva.Utils.Phone;

namespace Badge.Model
{
    public class ReportLog : PropertyChangedBaseClass 
    {

        public DateTime DateLog { get; set; }
        public LogEntry LogIn { get; set; }
        public LogEntry LogOut { get; set; }

        public string DateLogString
        {
            get
            {

                return DateLog.ToShortDateString();
            }
        }

        public string DescriptionIn
        {
            get
            {
                return LogIn == null ? string.Empty : LogIn.EntryTypeEnum.ToString();
            }
        }

        public string TimeIn
        {
            get
            {
                return LogIn == null ? string.Empty : LogIn.Time.ToShortTimeString();
            }
        }

        public string DescriptionOut
        {
            get
            {
                return LogOut == null ? string.Empty : LogOut.EntryTypeEnum.ToString();
            }
        }

        public string TimeOut
        {
            get
            {
                return LogOut == null ? string.Empty : LogOut.Time.ToShortTimeString();
            }
        }


        public ReportLog(LogEntry logIn, LogEntry logOut)
        {
            LogIn = logIn;
            LogOut = logOut;

            DateLog = LogIn.Time.Date;

        }


        public static List<ReportLog> ReadAll()
        {

            var list = new List<ReportLog>();

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString))
            {
               
                var entrylistIn = (from entry in db.Entries
                                 where entry.EntryTypeEnum == Enum.EntryType.In
                                   orderby entry.Time
                                select entry);
                var entrylistOut = (from entry in db.Entries
                                   where entry.EntryTypeEnum == Enum.EntryType.Out
                                   orderby entry.Time
                                   select entry);

                foreach (var item in entrylistIn) {
                    list.Add(new ReportLog(item,
                                            entrylistOut.FirstOrDefault(log => log.Time > item.Time) ));
                }
                
            }

            return list;
        }
    }

}
