using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.TextToSpeech;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuOrden : ContentPage 
	{
        //PopUpPrueba Lista;
        ListaAlimentos1 vm;
        public string idPhone;
        public string numSucursal;
        public string json;
        public MenuOrden (string idPhone1, string sucursal)
		{
            
            InitializeComponent();
            vm = new ListaAlimentos1();
            listaAlimentos.ItemsSource = vm.Tacos1;
            listaAlimentos2.ItemsSource = vm.Tortas1;
            BindingContext = vm;
            idPhone = idPhone1;
            numSucursal = sucursal;

            btnBack.Clicked += btnBack_ClickedAsync;

        }

        private async void Alimento_Seleccionado(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var alimento = e.Item as Taco1;

            // DisplayAlert(alimento.Precio, "hola", "adios");
            //PopupNavigation.Instance.PushAsync(new NewUserPopupPage());
            //PopupNavigation.Instance.PushAsync(page: new NewUserPopupPage(alimento.Descripcion, alimento.Imagen, alimento.Nombre, alimento.Precio));
            //PopupNavigation.Instance.PushAsync(page: new MenuPopup(alimento.Descripcion, alimento.Imagen, alimento.Nombre));
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpPallevar(alimento.Tipo, alimento.Descripcion,
                alimento.Imagen, alimento.Nombre, alimento.Precio,alimento.Indice, idPhone, numSucursal));
            /*string c ="0";
            await Task.Factory.StartNew(() => {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, alimento.Indice + ".txt");
                try
                {
                    var text = File.ReadAllText(filename);
                    c = text.Split('(')[1];
                }
                catch (FileNotFoundException)
                {
                }
            });

            Taco1 newTaco = alimento;
            newTaco.Cantidad = c;

            if (alimento.Indice.Equals("0"))
            {
                vm.Tacos1[0].Cantidad = c;
            }
            if (alimento.Indice.Equals("1"))
            {
                vm.Tacos1[0].Cantidad = c;
            }
            if (alimento.Indice.Equals("2"))
            {
                vm.Tacos1[0].Cantidad = c;
            }*/


        }
        private async void Alimento_Seleccionado2(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var alimento = e.Item as Tortas1;
            
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpPallevar(alimento.Tipo,alimento.Descripcion,
                alimento.Imagen, alimento.Nombre, alimento.Precio,alimento.Indice, idPhone, numSucursal));

        }
        /*
        public void GetList()
        {
            List<Taco> Lista2 = Lista.GetList();
           json = JsonConvert.SerializeObject(Lista2);
        }*/
        private async void BtnBackSucursales_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            
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
            await Task.Factory.StartNew(() => {
                var toastConfig = new ToastConfig("Orden Cancelada");
                toastConfig.SetDuration(2000);
                toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(255, 52, 0));
                toastConfig.SetMessageTextColor(System.Drawing.Color.FromArgb(255, 255, 255));
                toastConfig.SetPosition(ToastPosition.Top);

                UserDialogs.Instance.Toast(toastConfig);
            });
        }
        private void ConfirmarOrden_Clicked(object sender, EventArgs e)
        {
            string cant = null;
            var documents =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            for(int i = 0; i<=5; i++)
            {
                var filename = Path.Combine(documents, i.ToString() + ".txt");
                try
                {
                    var text = File.ReadAllText(filename);
                    cant = cant + text;
                }
                catch (FileNotFoundException) {
                }
            }

            if (cant != null)
            {
                Navigation.PushAsync(new PaLlevar3(idPhone, numSucursal, cant.Substring(0, cant.Length - 1)));
                CrossTextToSpeech.Current.Speak("Por favor revisa tu orden antes de pagar");
            }
            else {
                DisplayAlert("", "Debes agregar productos para poder revisar tu orden", "Entendido");
            }         
            
        }
     
        
        private async void btnBack_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

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

        }

        
    }
}