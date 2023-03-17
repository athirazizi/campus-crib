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
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Exploring_Clicked(object sender, EventArgs e)
        {

        }
    }
}