using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Badge.Model;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class TraceState : PropertyChangedBaseClass {

        public TraceState(){
            // 
        }

        private ObservableCollection<EntryType> entryTypes = new ObservableCollection<EntryType>() { EntryType.In, EntryType.Out };
        public ObservableCollection<EntryType> EntryTypes {
            get {
                return entryTypes;
            }
            set {
                entryTypes = value;
                NotifyPropertyChanged("EntryTypes");
            }
        }


        public static TraceState GetNew() {
            return new TraceState();
        }

        private LogEntry logEntryItem = new LogEntry();
        public LogEntry LogEntryItem {
            get {
                return logEntryItem;
            }
            set {
                logEntryItem = value;
            }
        }

        public EntryType LogType {
            get {
                return LogEntryItem.EntryTypeEnum;
            }
            set {
                LogEntryItem.EntryTypeEnum = value;
                NotifyPropertyChanged("LogType");
            }
        }

        public string LogTypeText {
            get {               
                return LogEntryItem.LogTypeText;
            }
            set {
                LogEntryItem.EntryTypeEnum = (EntryType)Enum.Parse(typeof(EntryType), value, true);
                NotifyPropertyChanged("LogTypeText");
            }
        }

        public string TimeText {
            get {
                return LogEntryItem.TimeText;
            }
            set {
                LogEntryItem.Time = DateTime.Parse(value);
                NotifyPropertyChanged("TimeText");
            }
        }
        
    }
}
