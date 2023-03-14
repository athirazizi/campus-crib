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
    public partial class HostelDetailsPage : ContentPage
    {
        App globalref = (App)Application.Current;

        public HostelDetailsPage()
        {
            InitializeComponent();
            BindingContext = globalref.selectedHostel;
        }
    }
}