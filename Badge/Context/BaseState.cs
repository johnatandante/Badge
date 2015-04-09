using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using Proattiva.Utils.Phone;

namespace Badge.Context {
    public class BaseState : PropertyChangedBaseClass {

        protected static BaseState appStateIstance = null;

        static BaseState() {
            appStateIstance = new BaseState();    
        }

        public static void SetNavigationService(NavigationService navi) {
            appStateIstance.NavigationService = navi;
        }

        public static NavigationService GetNavigationService() {
            return appStateIstance.NavigationService;
        }

        public NavigationService NavigationService { get; set; }
    }
}
