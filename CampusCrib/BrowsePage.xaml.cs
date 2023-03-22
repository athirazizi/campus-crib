using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowsePage : ContentPage
    {
        private HostelDatabase HostelDB = new HostelDatabase();
        private App globalref = (App)Application.Current;

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


            // Let the selected item persist into a new booking being created
            //((CollectionView)sender).SelectedItem = null;
        }

        private async void myRefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(500);
            myRefreshView.IsRefreshing = false;
        }
    }
}