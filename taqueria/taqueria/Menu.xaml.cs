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
    public partial class Menu : ContentPage
    {
        ListaAlimentos1 vm;
        public Menu()
        {

            InitializeComponent();
            vm = new ListaAlimentos1();
            listaAlimentos.ItemsSource = vm.Tacos1;
            listaAlimentos2.ItemsSource = vm.Tortas1;
            listaAlimentos3.ItemsSource = vm.Tacos;
            listaAlimentos4.ItemsSource = vm.Tortas;
            BindingContext = vm;



        }
        private async void Alimento_Seleccionado(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var alimento = e.Item as Taco1;

            // DisplayAlert(alimento.Precio, "hola", "adios");
            //PopupNavigation.Instance.PushAsync(new NewUserPopupPage());
            //PopupNavigation.Instance.PushAsync(page: new NewUserPopupPage(alimento.Descripcion, alimento.Imagen, alimento.Nombre, alimento.Precio));
            //PopupNavigation.Instance.PushAsync(page: new MenuPopup(alimento.Descripcion, alimento.Imagen, alimento.Nombre));
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpMenu(alimento.Descripcion,
                alimento.Imagen, alimento.Nombre, alimento.Precio, alimento.Tipo));

        }
        private async void Alimento_Seleccionado2(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var alimento2 = e.Item as Tortas1;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpMenu(alimento2.Descripcion,
                alimento2.Imagen, alimento2.Nombre, alimento2.Precio, alimento2.Tipo));
        }
        private async void Alimento_Seleccionado3(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var alimento3 = e.Item as Taco;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpMenu(alimento3.Descripcion,
                alimento3.Imagen, alimento3.Nombre, alimento3.Precio, alimento3.Tipo));
        }
        private async void Alimento_Seleccionado4(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var alimento4 = e.Item as Torta;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new PopUpMenu(alimento4.Descripcion,
                alimento4.Imagen, alimento4.Nombre, alimento4.Precio, alimento4.Tipo));
        }
        private void BtnBackSucursales_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


    }
}