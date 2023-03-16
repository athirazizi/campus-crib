using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    public partial class App : Application
    {
        public Hostel selectedHostel = new Hostel();

        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new MainPage());
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
