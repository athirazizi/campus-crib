using System;
using System.Linq;
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
            // Validation - email, phone, username, etc should be mandatory

            // if the field is empty
            // display error + set entry colour to red
            // else set entry colour to black (normal)

            if ((string.IsNullOrEmpty(txtFirstName.Text)) || (string.IsNullOrWhiteSpace(txtFirstName.Text)))
            {
                await DisplayAlert("Error", "Enter your first name.", "OK");
                txtFirstName.PlaceholderColor = Color.FromRgb(176,0,32);
            } 
            else
            {
                txtFirstName.TextColor = Color.Black;
            }

            if ((string.IsNullOrEmpty(txtLastName.Text)) || (string.IsNullOrWhiteSpace(txtLastName.Text)))
            {
                await DisplayAlert("Error", "Enter your last name.", "OK");
                txtLastName.PlaceholderColor = Color.FromRgb(176, 0, 32);
            }
            else
            {
                txtLastName.TextColor = Color.Black;
            }

            if ((string.IsNullOrEmpty(txtUsername.Text)) || (string.IsNullOrWhiteSpace(txtUsername.Text)))
            {
                await DisplayAlert("Error", "Enter your username.", "OK");
                txtUsername.PlaceholderColor = Color.FromRgb(176, 0, 32);
            }
            else
            {
                txtUsername.TextColor = Color.Black;
            }


            if ((string.IsNullOrEmpty(txtEmail.Text)) || (string.IsNullOrWhiteSpace(txtEmail.Text)))
            {
                await DisplayAlert("Error", "Enter your email.", "OK");
                txtEmail.PlaceholderColor = Color.FromRgb(176, 0, 32);
            }
            else
            {
                txtEmail.TextColor = Color.Black;
            }

            if ((string.IsNullOrEmpty(txtPhone.Text)) || (string.IsNullOrWhiteSpace(txtPhone.Text)))
            {
                await DisplayAlert("Error", "Enter your phone number.", "OK");
                txtPhone.PlaceholderColor = Color.FromRgb(176, 0, 32);
            }
            else
            {
                txtPhone.TextColor = Color.Black;
            }

            if ((string.IsNullOrEmpty(txtPassword.Text)) || (string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                await DisplayAlert("Error", "Enter your password.", "OK");
                txtPassword.PlaceholderColor = Color.FromRgb(176, 0, 32);
            }
            else
            {
                txtPassword.TextColor = Color.Black;
            }


            if ((string.IsNullOrEmpty(txtConfirmPassword.Text)) || (string.IsNullOrWhiteSpace(txtConfirmPassword.Text)))
            {
                await DisplayAlert("Error", "Confirm your password.", "OK");
                txtConfirmPassword.PlaceholderColor = Color.FromRgb(176, 0, 32);
            }
            else
            {
                txtConfirmPassword.TextColor = Color.Black;
            }

            // if the username is not empty + if the user has provided their email & phone + if the password is not empty + the passwords match
            // store user data inside the database.

            if (
                !(string.IsNullOrEmpty(txtPassword.Text)) && !(string.IsNullOrWhiteSpace(txtPassword.Text))
                && !(string.IsNullOrEmpty(txtUsername.Text)) && !(string.IsNullOrWhiteSpace(txtUsername.Text))
                && !(string.IsNullOrEmpty(txtEmail.Text)) && !(string.IsNullOrEmpty(txtPhone.Text))
                && (txtPassword.Text == txtConfirmPassword.Text)
                )
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

                await DisplayAlert("Success", "Registration successful for new user: " + txtUsername.Text, "Go to Login");
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Error", "Passwords do not match or form is incomplete. Try again.", "OK");
            }
        }
    }
}