using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text) // Validation - email, phone, username, etc should be mandatory
            {
                HostelDatabase newDBInstance;
                newDBInstance = new HostelDatabase();

                var newUser = new User
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text
                };

                newDBInstance.AddUser(newUser);

                await DisplayAlert("Success!", "Sign Up successful for username " + txtUsername.Text, "Go to Login");
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Error", "Passwords do not match. Try again", "OK");
            }
        }
    }
}