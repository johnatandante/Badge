using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Badge.Database;
using Badge.Model;

namespace Badge.Controller {
    public class ReportLogDataService {

        public static List<ReportLog> ReadAll() {

            var list = new List<ReportLog>();

            using (BadgeDataContext db = new BadgeDataContext(BadgeDataContext.ConnectionString)) {

                var entrylistIn = (from entry in db.Entries
                                   where entry.EntryTypeEnum == Model.EntryType.In
                                   orderby entry.Time
                                   select entry);
                var entrylistOut = (from entry in db.Entries
                                    where entry.EntryTypeEnum == Model.EntryType.Out
                                    orderby entry.Time
                                    select entry);

                foreach (var item in entrylistIn) {
                    list.Add(new ReportLog(item,
                                            entrylistOut.FirstOrDefault(log => log.Time > item.Time)));
                }

            }

            return list;
        }

    }
}
