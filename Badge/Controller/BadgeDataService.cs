using System;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Badge.Context;
using Badge.Model;

namespace Badge.Controller {
    public class BadgeDataService {

        public static void LoadLogData() {
            MenuItemDataService.LoadMenu();
            GraphLogDataService.LoadSupportedPeriods();
            GraphLogDataService.LoadGraphData();
        }

        public static void SetNavigationService(NavigationService navi) {
            BadgeState.Current.NavigationService = navi;
        }

        public static NavigationService GetNavigationService() {
            return BadgeState.Current.NavigationService;
        }

    }
}