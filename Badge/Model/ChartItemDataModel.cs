using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badge.Model {
    public class ChartItemDataModel {

        public ChartItemDataModel()
            : this(DateTime.Now.Date, PeriodType.All, DateTime.Now.ToString()) {

        }

        public ChartItemDataModel(DateTime day, PeriodType period, string itemValue) {
            // TODO: Complete member initialization
            Day = day;
            Period = period;
            ItemValue = DateTime.Parse(itemValue);
            ItemLabel = GetIndependentValuePath();
        }

        public DateTime Day { get; set; }
        public DateTime ItemValue { get; set; }
        public PeriodType Period { get; set; }
        public string ItemLabel { get; set; }

        public string DayNumber {
            get {
                return Day.Day.ToString();
            }
        }

        public int Month {
            get {
                return Day.Month;
            }
        }

        public string DayOfTheWeek {
            get {
                return Day.DayOfWeek.ToString();
            }
        }

        public string MonthDay {
            get {
                return Day.ToString("dd/MM");
            }
        }

        public string FullDate {
            get {
                return Day.ToString("dd/MM/yyyy");
            }
        }

        private string GetIndependentValuePath() {
            switch (Period) {
                case PeriodType.LastWeek:
                    return DayOfTheWeek;
                case PeriodType.LastMonth:
                    // return DayNumber.ToString();
                case PeriodType.Last2Months:
                case PeriodType.Last6Months:
                    return MonthDay;
                case PeriodType.LastYear:
                case PeriodType.All:
                default:
                    return FullDate;

            }
        }

    }
}
