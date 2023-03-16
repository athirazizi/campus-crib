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
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
		}

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success!", "Sign Up Succesful", "Ok");
            await Navigation.PushAsync(new LoginPage());
        }
    }
}