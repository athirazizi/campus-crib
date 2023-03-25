using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace CampusCrib
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            // prevent user from swiping between tabbed pages
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }

        protected override bool OnBackButtonPressed()
        {
            // prevent user from going back to login page
            return true;
        }

        private async void tbLogout_Clicked(object sender, EventArgs e)
        {
            // User can still navigate backwards into the app's pages after logout is tapped, clear the nav stack then create the new LoginPage
            await Navigation.PopToRootAsync();
        }
    }
}
