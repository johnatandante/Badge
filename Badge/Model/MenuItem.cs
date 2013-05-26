using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proattiva.Utils.Phone;

namespace Badge.Model {
    public class MenuItem {

        public string Name { get; set; }
        public string Destination { get; set; }
        public string Info { get; set; }
        public string ImagePath { get; set; }

        public Action CallBackAction { get; set; }

    }
}
