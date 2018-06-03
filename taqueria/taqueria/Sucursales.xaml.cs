using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sucursales : ContentPage
	{
		public Sucursales ()
		{
			InitializeComponent ();
            ConfigSucursal1();
            ConfigSucursal2();
            ConfigSucursal3();

            BtnBackSucursales.Clicked += BtnBackSucursales_Clicked;

            
		}

        private void ConfigSucursal3()
        {
            MapSuc3.MoveToRegion(
               MapSpan.FromCenterAndRadius(new Position(21.8568775, -102.2680439), Distance.FromMiles(.05)));
            var position3 = new Position(21.856918, -102.268068); // Latitude, Longitude
            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "Suc. Morelos",
                Address = "30 de Julio 410, Morelos 1"
            };
            MapSuc3.Pins.Add(pin3);
        }

        private void ConfigSucursal2()
        {
            MapSuc2.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(21.8746075, -102.3108518), Distance.FromMiles(.05)));
            var position2 = new Position(21.874750, -102.310943); // Latitude, Longitude
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "Suc. Feria",
                Address = "Nieto 913, Modelo"
            };
            MapSuc2.Pins.Add(pin2);
        }

        private void ConfigSucursal1()
        {
            MapSuc1.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(21.893640, -102.290485), Distance.FromMiles(.05)));
            var position = new Position(21.893644, -102.290548); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Suc. Centro",
                Address = "Barragán 1002, Gremial"
            };
            MapSuc1.Pins.Add(pin);

        }

        private void BtnBackSucursales_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}