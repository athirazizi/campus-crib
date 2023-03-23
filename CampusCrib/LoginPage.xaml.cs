using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        private App globalref = (App)Application.Current;

        public LoginPage()
        {
            InitializeComponent();

        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            // Check for the existence of a user, if they exist, let them log in. Set the user to the current user.
            HostelDatabase newDBInstance;

            newDBInstance = new HostelDatabase();

            var checkLogin = newDBInstance.CheckLogin(txtUsername.Text, txtPassword.Text);

            if (checkLogin!= null)
            {
                globalref.currentUser = checkLogin;
                await Navigation.PushAsync(new MainPage());
            }

            else
            {
                await DisplayAlert("Error", "Entered username & password does not exist. Try again.", "OK");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}