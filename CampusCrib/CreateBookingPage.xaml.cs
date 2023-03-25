using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateBookingPage : ContentPage
    {
        CreateBookingPageVM createbookingpagevm;

 

        public CreateBookingPage()
        {
            InitializeComponent();

            createbookingpagevm = new CreateBookingPageVM();
            BindingContext = createbookingpagevm;

            // For setting the minimum start date to today, minimum end date to tomorrow
            DateTime today = DateTime.Now;
            pickerStartDate.MinimumDate = today;
            var tomorrow = today.AddDays(1);
            pickerEndDate.MinimumDate = tomorrow;

        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            // Ensure user is happy with details, then save the booking
            var ans = await DisplayAlert("Create Booking", "Are you sure your booking details are correct?\n\nBookings can be edited in the Bookings Page."
              , "Yes", "No");
            if (ans)
            {
                createbookingpagevm.SaveBooking();
            } 

        }
    }
}