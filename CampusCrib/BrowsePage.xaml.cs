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
        HostelDatabase HostelDB = new HostelDatabase();
        App globalref = (App)Application.Current;

        public BrowsePage()
        {
            InitializeComponent();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App globalref = (App)Application.Current;

            var hostel = ((CollectionView)sender).SelectedItem as Hostel;

            globalref.selectedHostel = hostel;

            if (hostel == null)
            {
                return;
            }

            Navigation.PushAsync(new HostelDetailsPage());
            ((CollectionView)sender).SelectedItem = null;
        }

        
    }
}