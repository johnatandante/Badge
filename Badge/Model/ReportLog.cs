using System;
using System.Linq;
using System.Collections.Generic;
using Badge.Database;

namespace Badge.Model
{
    public class ReportLog
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
                return LogIn.EntryTypeEnum.ToString();
            }
        }

        public string TimeIn
        {
            get
            {
                return LogIn.Time.ToShortTimeString();
            }
        }

        public string DescriptionOut
        {
            get
            {
                return LogOut.EntryTypeEnum.ToString();
            }
        }

        public string TimeOut
        {
            get
            {
                return LogOut.Time.ToShortTimeString();
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

            var list = default(List<ReportLog>);

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString))
            {
                var entrylist = db.Entries.ToList();
                if (entrylist.Count == 2)
                {
                    list.Add(new ReportLog(entrylist[0], entrylist[1]));
                }
                
            }

            return list;
        }
    }

}
