using AutoAppo_StevenVR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAppo_StevenVR.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_StevenVR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAppointmentListPage : ContentPage
    {
        UserViewModel vm;

        public MyAppointmentListPage()
        {
            InitializeComponent();

            BindingContext = vm = new UserViewModel();

            LoadAppos(GlobalObjects.LocalUser.IDUsuario);
        }

        private async void LoadAppos(int pUserID)
        {
            LstAppoList.ItemsSource = await vm.GetAppoList(pUserID);
        }

    }
}
