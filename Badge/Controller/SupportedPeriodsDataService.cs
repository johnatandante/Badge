using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Badge.Model;

namespace Badge.Controller {
    public class SupportedPeriodsDataService {

        internal static bool FitsOnPeriod(DateTime dateTime, PeriodType period, DateTime? toDate = null) {
            if (!toDate.HasValue)
                toDate = DateTime.Now;

            var isCurrentYear = dateTime.Year == toDate.Value.Year;
            switch (period) {
                case PeriodType.LastWeek:
                    var span = new TimeSpan(toDate.Value.Ticks - dateTime.Ticks);
                    return isCurrentYear && dateTime.DayOfWeek >= DayOfWeek.Sunday && span.TotalDays <= 7;
                case PeriodType.LastMonth:
                    return isCurrentYear && dateTime.Month == toDate.Value.Month;
                case PeriodType.Last2Months:
                    return isCurrentYear && dateTime.Month >= toDate.Value.Month - 2 && dateTime.Month <= toDate.Value.Month;
                case PeriodType.Last6Months:
                    return isCurrentYear && dateTime.Month >= toDate.Value.Month - 6 && dateTime.Month <= toDate.Value.Month;
                case PeriodType.LastYear:
                    return isCurrentYear;
                case PeriodType.All:
                default:
                    return true;
            }
        }


    }
}
