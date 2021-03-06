﻿using CheckerApp.Mobile.Views;
using Xamarin.Forms;

namespace CheckerApp.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Startup.Init();

            MainPage = new AppShell();
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
