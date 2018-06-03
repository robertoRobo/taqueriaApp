using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.TextToSpeech;
using scanner.cuerpos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taqueria.cuerpos;
using taqueria.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaLlevar3 : ContentPage
    {
        private ObservableCollection<OrdenModel> order { get; set; }

        private const string V = "$";
        string idPhone1;
        int sucursal1;
        int total1;
        string descripcion1;
        public PaLlevar3 (string idPhone,string sucursal, string json)
		{
            idPhone1 = idPhone;
            sucursal1 = Int32.Parse(sucursal);
            total1 = 0;
            descripcion1 = json;
            //descripcion1 = "Taco Al Pastor (9";
            InitializeComponent ();
            order = new ObservableCollection<OrdenModel>();
            btnCancelarOrden.Clicked += BtnCancelarOrden_Clicked;
            btnModificarOrden.Clicked += BtnModificarOrden_Clicked;
            btnConfirmarOrden.Clicked += BtnConfirmarOrden_Clicked;

            listOrden.ItemsSource = order;
            var actualF = DateTime.Today;
            fecha.Text = actualF.ToString("d");

            /*order.Add(new OrdenModel() { Platillo = "Taco Al Pastor", Cantidad = "Cantidad: 20" });
            order.Add(new OrdenModel() { Platillo = "Taco Suadero", Cantidad = "Cantidad: 15" });
            order.Add(new OrdenModel() { Platillo = "Torta Al Pastor", Cantidad = "Cantidad: 1" });
            order.Add(new OrdenModel() { Platillo = "Torta Suadero", Cantidad = "Cantidad: 3" });*/

            foreach (string plato in descripcion1.Split(','))
            {
                // desc += "{" + plato.Split('(')[0]+" "+ plato.Split('(')[1] + "}";
                order.Add(new OrdenModel() { Platillo = plato.Split('(')[0], Cantidad = plato.Split('(')[1] });

                total1 += Int32.Parse(plato.Split('(')[2]);
            }

            total.Text = V + total1.ToString();

            
        }

        private async void BtnConfirmarOrden_Clicked(object sender, EventArgs e)
        {
            var activo = true;
            promocion p = null;
            await Task.Factory.StartNew(() =>
            {
                UserDialogs.Instance.ShowLoading("Estamos procesando tu pago");
                new restClient().insertOrden(idPhone1, sucursal1, descripcion1, total1);
                p = new restClient().insertPromo(idPhone1);
                UserDialogs.Instance.HideLoading();
                activo = false;
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                for (int i = 0; i <= 5; i++)
                {
                    var filename = Path.Combine(documents, i.ToString() + ".txt");
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (FileNotFoundException)
                    {
                    }
                }
            });

            if (activo == false) {
                await Navigation.PopToRootAsync();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpConfirmacion());
                if (p.exists)
                {
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopupOferta(idPhone1));
                }
            }

        }

        private void BtnModificarOrden_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void BtnCancelarOrden_Clicked(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                for (int i = 0; i <= 5; i++)
                {
                    var filename = Path.Combine(documents, i.ToString() + ".txt");
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (FileNotFoundException)
                    {
                    }
                }
            });

            await Navigation.PopToRootAsync();

            await Task.Factory.StartNew(() => {
                var toastConfig = new ToastConfig("Orden Cancelada");
                toastConfig.SetDuration(2000);
                toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(255, 52, 0));
                toastConfig.SetMessageTextColor(System.Drawing.Color.FromArgb(255, 255, 255));
                toastConfig.SetPosition(ToastPosition.Top);

                UserDialogs.Instance.Toast(toastConfig);
            });
        }


    }
	
}