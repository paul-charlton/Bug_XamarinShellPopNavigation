using ShellPopIssue.ViewModels;
using ShellPopIssue.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ShellPopIssue
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private bool _started;

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            _started = true;
        }

        protected override void OnAppearing()
        {
            // hopefully to stop a null ref exception in shell code
            this.SetValue(NavBarIsVisibleProperty, false);

            base.OnAppearing();
        }

        protected override void OnChildRemoved(Element child, int oldLogicalIndex)
        {
            base.OnChildRemoved(child, oldLogicalIndex);
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            Debug.WriteLine($"NavigatED From: {args.Previous?.Location?.ToString() ?? "-"}; To:  {args.Current?.Location?.ToString() ?? "-"}; By: {args.Source.ToString()};");

            if (!_started)
                return;

            var shellSection = Shell.Current?.CurrentItem;
            var shellContent = shellSection?.CurrentItem;
            var items = shellContent?.Items;
            var stack = shellContent?.Stack;

            Debug.WriteLine($"Stack Count: {stack?.Count ?? -1}");

            /*
             * Now using the Pre-nav option
            if (args.Current?.Location.ToString().Equals("//home/myhealth/default", System.StringComparison.InvariantCultureIgnoreCase) == true && !PrototypeService.IsUserAuthenticated)
            {
                // just push to new page
                await GoToAsync("myhealth/guest", false).ConfigureAwait(false);
            }*/
        }

        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            Debug.WriteLine($"NavigatING From: {args.Current?.Location?.ToString() ?? "-"}; To:  {args.Target?.Location?.ToString() ?? "-"}; By: {args.Source.ToString()};");

            /*
#if DEBUG
            var test = Shell.GetNavBarIsVisible(new MyCareHubPage());
            var test2 = Shell.GetNavBarIsVisible(new MyHealthGuestPage());

            var shellSection = Shell.Current?.CurrentItem;
            var shellContent = shellSection?.CurrentItem;
            var items = shellContent?.Items;
            var stack = shellContent?.Stack;

            if (!_shownKeys)
            {
                var keys = typeof(Routing).GetMethod("GetRouteKeys", BindingFlags.Static | BindingFlags.NonPublic)?.Invoke(null, null) as string[] ?? new string[0];
                if (keys?.Length > 0)
                {
                    Debug.WriteLine($"Routing Keys:\r\n{string.Join("\r\n", keys)}");
                    _shownKeys = true;
                }
            }
#endif
            */
            if (!_started)
                return;

            // this is weird but it seems to leave a load of stuff on the stack that stops navigation working??
            if (args.Current?.Location?.ToString()?.Equals(args.Target?.Location?.ToString() ?? "-") == true && args.Source == ShellNavigationSource.ShellSectionChanged)
                await Current.Navigation.PopToRootAsync().ConfigureAwait(false);
        }
    }
}