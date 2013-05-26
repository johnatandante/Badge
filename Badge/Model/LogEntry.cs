using Badge.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using Badge.Database;

namespace Badge.Model
{
    [Table]
    public class LogEntry {

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public decimal Id { get; set; }

        [Column]
        public DateTime Time { get; set; }

        [Column]
        public EntryType EntryTypeEnum { get; set; }

        public string LogTypeText {
            get {               
                return EntryTypeEnum.ToString();
            }
        }

        public string TimeText {
            get {
                return Time.ToString();
            }
        }

        internal static LogEntry NewLogIn() {
            return new LogEntry() { EntryTypeEnum = Model.EntryType.In };
        }

        internal static LogEntry NewLogOut() {
            return new LogEntry() { EntryTypeEnum = Model.EntryType.Out };
        }

    }
}


