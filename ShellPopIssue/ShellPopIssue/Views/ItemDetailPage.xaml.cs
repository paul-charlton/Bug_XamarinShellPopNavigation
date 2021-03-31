using ShellPopIssue.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShellPopIssue.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}