using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taqueria
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpConfirmacion
	{
		public PopUpConfirmacion ()
		{
			InitializeComponent ();
            CloseWhenBackgroundIsClicked = false;

            btnAck.Clicked += BtnAck_Clicked;
		}

        private void BtnAck_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}