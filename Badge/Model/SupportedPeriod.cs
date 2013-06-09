using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badge.Model {
    public enum PeriodType {
        LastWeek,
        LastMonth,
        Last2Months,
        Last6Months,
        LastYear,
        All,
    }

    public class SupportedPeriod {

        private static DateTime DbFirstDate = new DateTime(1971, 1, 1);

        public static Dictionary<PeriodType, string> DecodePeriodType = new Dictionary<PeriodType, string>() {
            { PeriodType.LastWeek, "Last Week" },
            { PeriodType.LastMonth, "Last Month"},
            { PeriodType.Last2Months, "Last 2 Months"},
            { PeriodType.Last6Months, "Last 6 Months"},
            { PeriodType.LastYear, "Last Year"},
            { PeriodType.All, "All of it"},
        };

        public static Dictionary<PeriodType, TimeSpan> Spans = new Dictionary<PeriodType, TimeSpan>() {
             { PeriodType.LastWeek, new TimeSpan(7, 0, 0, 0) } ,
             { PeriodType.LastMonth, new TimeSpan(30, 0, 0, 0, 0) } ,
             { PeriodType.Last2Months, new TimeSpan(60, 0, 0, 0) } ,
             { PeriodType.Last6Months, new TimeSpan(180, 0, 0, 0) } ,
             { PeriodType.LastYear, new TimeSpan(360, 0, 0, 0) } ,
             { PeriodType.All, new TimeSpan(0) } ,
        };

        private PeriodType period = PeriodType.All;
        public PeriodType Period {
            get {
                return period;
            }
            set {
                period = value;
                Description = DecodePeriodType[Period];
            }
        }

        public string Description { get; set; }
        public TimeSpan Span {
            get {
                return Spans[Period];
            }
        }

        public DateTime From {
            get {
                return Period == PeriodType.All ? DbFirstDate : To.Subtract(Spans[Period]);
            }
        }

        public DateTime To { get; set; }

        public SupportedPeriod()
            : this(DateTime.Now, PeriodType.All) {

        }

        public SupportedPeriod(DateTime to, PeriodType period) {
            Period = period;
            To = to;

        }

    }
}
