using AutoAppo_StevenVR.Models;
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
    public partial class UserManagmentPage : ContentPage
    {
        UserViewModel vm;

        public UserManagmentPage()
        {
            InitializeComponent();

            BindingContext = vm = new UserViewModel();

            LoadUserData();

        }

        private void LoadUserData()
        {
            TxtID.Text = GlobalObjects.LocalUser.IDUsuario.ToString();
            TxtName.Text = GlobalObjects.LocalUser.Nombre;
            TxtEmail.Text = GlobalObjects.LocalUser.Correo;
            TxtPhone.Text = GlobalObjects.LocalUser.NumeroTelefono;
            TxtIDNumber.Text = GlobalObjects.LocalUser.Cedula;
            TxtAddress.Text = GlobalObjects.LocalUser.Direccion;
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {

            if (ValidateUserData())
            { 
                UserDTO BackUpUser = new UserDTO();
                BackUpUser = GlobalObjects.LocalUser;

                GlobalObjects.LocalUser.Nombre = TxtName.Text.Trim();
                GlobalObjects.LocalUser.Correo = TxtEmail.Text.Trim();
                GlobalObjects.LocalUser.NumeroTelefono = TxtPhone.Text.Trim();
                GlobalObjects.LocalUser.Cedula = TxtIDNumber.Text.Trim();
                GlobalObjects.LocalUser.Direccion = TxtAddress.Text.Trim();


                if (TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    GlobalObjects.LocalUser.Contrasennia = TxtPassword.Text.Trim();
                }

                var answer = await DisplayAlert("Confirmation required", "Are you sure to update your info?", "Yes", "No");

                if (answer)
                {
                    try
                    {
                        bool R = await vm.UpdateUser(GlobalObjects.LocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "User updated!", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something went wrong!", "OK");
                            GlobalObjects.LocalUser = BackUpUser;
                        }
                    }
                    catch (Exception)
                    {
                        GlobalObjects.LocalUser = BackUpUser;
                    }

                }


            }

        }

        private bool ValidateUserData()
        {
            bool R = false;
            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim()))
            {
                R = true;
            }
            else
            { 
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "The Name is required", "OK");
                    TxtName.Focus();
                    return false;
                }

                if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "The Email is required", "OK");
                    TxtEmail.Focus();
                    return false;
                }

                if (TxtPhone.Text == null || string.IsNullOrEmpty(TxtPhone.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "The Phone Number is required", "OK");
                    TxtPhone.Focus();
                    return false;
                }

            }

            return R;

        }


        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}