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
    public partial class BrowsePage : ContentPage
    {
        AllHostelsVM allhostelsVM;

        public BrowsePage()
        {
            InitializeComponent();
            allhostelsVM = new AllHostelsVM();
            BindingContext = allhostelsVM;
        }

        private void lstvwHostels_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App globalref = (App)Application.Current;

            if (e.SelectedItem != null)
            {
                globalref.selectedHostel = lstvwHostels.SelectedItem as Hostel;

                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}