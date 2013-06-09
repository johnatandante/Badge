using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class BaseState : PropertyChangedBaseClass {

        protected static BaseState istance;

        public static void SetNavigationService(NavigationService navi) {
            istance.NavigationService = navi;
        }

        public static NavigationService GetNavigationService() {
            return istance.NavigationService;
        }

        public NavigationService NavigationService { get; set; }
    }
}
