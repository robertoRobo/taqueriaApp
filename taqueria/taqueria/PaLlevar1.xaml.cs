using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaLlevar1 : ContentPage
	{
        string idPhone1;
        public PaLlevar1(string idPhone)
        {
            idPhone1 = idPhone;
            InitializeComponent();

            btnBackSucursalesOrden.Clicked += BtnBackSucursalesOrden_ClickedAsync;
            btnSuc1.Clicked += BtnSuc1_Clicked;
            btnSuc2.Clicked += BtnSuc2_Clicked;
            btnSuc3.Clicked += BtnSuc3_Clicked;

        }

        private async void BtnSuc3_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("");
            try
            {
                await Navigation.PushAsync(new MenuOrden(idPhone1,"3"));
                Task.Delay(1000).Wait();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void BtnSuc2_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("");
            try
            {
                await Navigation.PushAsync(new MenuOrden(idPhone1, "2"));
                //await Navigation.PushAsync(new PaLlevar3(idPhone1, "2"));
                Task.Delay(1000).Wait();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void BtnSuc1_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("");
            try
            {
                await Navigation.PushAsync(new MenuOrden(idPhone1, "1"));
                //await Navigation.PushAsync(new PaLlevar3(idPhone1, "3"));
                Task.Delay(1000).Wait();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
            

        }

        private async void BtnBackSucursalesOrden_ClickedAsync(object sender, EventArgs e)
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

            
            await Navigation.PopAsync();

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