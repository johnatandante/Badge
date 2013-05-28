using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badge.Model {
    public class ChartItemDataModel {

        public ChartItemDataModel() {
            Day = DateTime.Now.Date;
            ItemValue = DateTime.Now;
        }

        public ChartItemDataModel(DateTime day, string itemValue) {
            // TODO: Complete member initialization
            Day = day;
            ItemValue = DateTime.Parse(itemValue);

        }

        public DateTime Day { get; set; }
        public DateTime ItemValue  { get; set; }

    }
}
