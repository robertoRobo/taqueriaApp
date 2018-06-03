using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using scanner.cuerpos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace taqueria
{
	public partial class MainPage : ContentPage
	{
        Boolean respG;
        string idPhone1;
        public MainPage(string idPhone)
        {
            idPhone1 = idPhone; 
            InitializeComponent();
            btnSucursales.Clicked += BtnSucursales_Clicked;
            btnMenu.Clicked += BtnMenu_Clicked;
            btnOrdenes.Clicked += BtnOrdenes_Clicked;
            btnPaLevar.Clicked += BtnPaLevar_Clicked;
        }

        private async void BtnPaLevar_Clicked(object sender, EventArgs e)
        {
            respG = false;
            await Task.Factory.StartNew(() =>
            {
                UserDialogs.Instance.ShowLoading("");
                respG = new restClient().validaLimCompras(idPhone1);
                UserDialogs.Instance.HideLoading();
            });
            do
            {
                if (respG.Equals(true))
                {
                    respG = false;
                    await Navigation.PushAsync(new PaLlevar1(idPhone1));
                    break;
                }
                else
                {
                    respG = false;
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpPrueba());
                    //await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpConfirmacion());
                    break;
                }
            } while (respG.Equals(true));
        }

        private async void BtnOrdenes_Clicked(object sender, EventArgs e)
        {
            
            UserDialogs.Instance.ShowLoading("");
            try
            {
                await Navigation.PushAsync(new Ordenes(idPhone1));
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }

        }

        private async void BtnSucursales_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("");
            try
            {
                await Navigation.PushAsync(new Sucursales());
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void BtnMenu_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("");
            try
            {
                await Navigation.PushAsync(new Menu());
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}
