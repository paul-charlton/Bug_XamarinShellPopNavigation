using ShellPopIssue.Services;
using ShellPopIssue.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellPopIssue
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Routing.RegisterRoute("pushpop", typeof(PushPopPage));

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new NotAShell());
        }

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }
    }
}