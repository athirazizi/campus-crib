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
    public partial class BookingDetailsPage : ContentPage
    {

        BookingDetailsPageVM bookingdetailspagevm;

        public BookingDetailsPage()
        {
            InitializeComponent();

            bookingdetailspagevm = new BookingDetailsPageVM();
            BindingContext = bookingdetailspagevm;

            // For setting the minimum start date to today, minimum end date to tomorrow
            DateTime today = DateTime.Now;
            pickerStartDate.MinimumDate = today;
            var tomorrow = today.AddDays(1);
            pickerEndDate.MinimumDate = tomorrow;
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var ans = await DisplayAlert("Update Booking", "Are you sure your updated details are correct?\n\nOld details will be lost."
              , "Yes", "No");
            if (ans)
            {
                bookingdetailspagevm.UpdateBooking();
            }
         
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var ans = await DisplayAlert("Delete Booking", "Are you sure you want to delete this booking?\n\nData will be lost forever."
               , "Yes", "No");
            if (ans)
            {
               bookingdetailspagevm.DeleteBooking();
            }
     
        }
    }
}