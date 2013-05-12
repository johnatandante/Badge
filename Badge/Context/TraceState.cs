using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Badge.Model;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class TraceState : PropertyChangedBaseClass {

        private static TraceState istance;
        public static TraceState Current {
            get {
                if (istance == null)
                    istance = new TraceState();

                return istance;
            }
        }

        public ObservableCollection<EntryType> EntryTypes {
            get {
                return new ObservableCollection<EntryType>() { EntryType.In, EntryType.Out };
            }
            set {
                //
            }
        }

    }
}
