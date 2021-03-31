using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellPopIssue.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            StartButton.Command = new Command(async () => await Shell.Current.GoToAsync("pushpop").ConfigureAwait(false));
        }
    }
}