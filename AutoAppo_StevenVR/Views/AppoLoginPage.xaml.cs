using Acr.UserDialogs;
using AutoAppo_StevenVR.ViewModels;
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
    public partial class AppoLoginPage : ContentPage
    {
        UserViewModel viewModel;

        public AppoLoginPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new UserViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //LOGIN
            bool R = false;

            if (TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                //si hay datos en el usuario y contraseña se puede continuar 
                try
                {
                    UserDialogs.Instance.ShowLoading("Cheking User Access...");
                    await Task.Delay(2000);

                    string email = TxtEmail.Text.Trim();
                    string password = TxtPassword.Text.Trim();

                    R = await viewModel.UserAccessValidation(email, password);




                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            else
            {
                await DisplayAlert("Validation Error", "User Email and Password are required!", "OK");
                return;
            }


            if (R)
            {
                //en caso que R sea true, entonces cargamos un usuario global igual que en progra 5

                GlobalObjects.LocalUser = await viewModel.GetUserData(TxtEmail.Text.Trim());

                await Navigation.PushAsync(new OptionPage());

                return;
            }
            else
            {
                await DisplayAlert("Validation Failed", "Access Denied!!", "OK");
                return;
            }

        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SignUpPage());

        }

        private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
        {

            if (SwShowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }

        }

        private async void LblPasswordRecovery_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PasswordRecoveryPage());
        }








    }
}