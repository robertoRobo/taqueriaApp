using scanner.cuerpos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taqueria.cuerpos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupOferta
	{
        string idPhone;

		public PopupOferta (string user)
		{
            idPhone = user;

			InitializeComponent ();
            CloseWhenBackgroundIsClicked = false;

            promocion promo = new restClient().insertPromo(idPhone);
            razon.Text = promo.Razon;
            img.Source = promo.promo;

            btnAck.Clicked += BtnAck_Clicked;
        }

        private void BtnAck_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}