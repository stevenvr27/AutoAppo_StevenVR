using AutoAppo_StevenVR.Services;
using AutoAppo_StevenVR.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_StevenVR
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new  NavigationPage(new AppoLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
