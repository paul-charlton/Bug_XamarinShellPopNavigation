using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellPopIssue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PushPopPage : ContentPage
    {
        public PushPopPage()
        {
            InitializeComponent();

            PushTheButton.Command = new Command(async () => await Shell.Current.GoToAsync("pushpop").ConfigureAwait(false));
            PopTheButton.Command = new Command(async () => await Shell.Current.Navigation.PopAsync().ConfigureAwait(false));
        }
    }
}