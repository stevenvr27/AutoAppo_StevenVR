using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_StevenVR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionPage : ContentPage
    {
        public OptionPage()
        {
            InitializeComponent();
        }

        private async Task BtnUserManagment_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserManagmentPage());

             
        }

        private async void BtnAppoManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyAppointmentListPage());
        }

        private void BtnUserManagment_Clicked(object sender, EventArgs e)
        {

        }
    }
}