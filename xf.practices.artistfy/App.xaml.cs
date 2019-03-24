﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xf.practices.artistfy.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace xf.practices.artistfy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListArtistPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
