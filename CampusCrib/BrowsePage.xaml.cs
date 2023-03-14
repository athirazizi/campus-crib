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

        public BrowsePage()
        {
            InitializeComponent();
            sampleData();
            lstvwHostels.ItemsSource = HostelDB.GetAllHostel();
            
        }

        public void sampleData()
        {
            Hostel hostel0 = new Hostel();
            hostel0.Name = "H0 name";
            hostel0.Description = "H0 desc";
            HostelDB.AddHostel(hostel0);

            Hostel hostel1 = new Hostel();
            hostel1.Name = "H1 name";
            hostel1.Description = "H1 desc";
            HostelDB.AddHostel(hostel1);

            Hostel hostel2 = new Hostel();
            hostel2.Name = "H2 name";
            hostel2.Description = "H2 desc";
            HostelDB.AddHostel(hostel2);

            Hostel hostel3 = new Hostel();
            hostel3.Name = "H3 name";
            hostel3.Description = "H3 desc";
            HostelDB.AddHostel(hostel3);

            Hostel hostel4 = new Hostel();
            hostel4.Name = "H4 name";
            hostel4.Description = "H4 desc";
            HostelDB.AddHostel(hostel4);

            Hostel hostel5 = new Hostel();
            hostel5.Name = "H5 name";
            hostel5.Description = "H5 desc";
            HostelDB.AddHostel(hostel5);
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