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

        private void tbLogout_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
