using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingsPage : ContentPage
    {
        private BookingsPageVM bookingspagevm;

        public BookingsPage()
        {
            InitializeComponent();
            bookingspagevm = new BookingsPageVM();
            BindingContext = bookingspagevm;
        }


        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App globalref = (App)Application.Current;

            // check for invalid selection
            if (e.SelectedItem == null)
            {
                return;
            }

            var selectedBooking = ((ListView)sender).SelectedItem as Booking;

            globalref.selectedBooking = selectedBooking;

            // Need to deselect the item on the UI after this, otherwise it will stick
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new BookingDetailsPage());
        }
    }
}