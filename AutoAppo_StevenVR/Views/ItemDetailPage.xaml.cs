using AutoAppo_StevenVR.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AutoAppo_StevenVR.Views
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