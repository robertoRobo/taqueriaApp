using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.TextToSpeech;


namespace taqueria
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpMenu
    {
        public Taco AlimentoNuevo { get; set; }
        
        public PopUpMenu(string descripcion, string imagen, string nombre, string precio, string tipo)
        {

            InitializeComponent();
            AlimentoNuevo = new Taco();
            AlimentoNuevo.Tipo = tipo;
            AlimentoNuevo.Nombre = nombre;
            AlimentoNuevo.Descripcion = descripcion;
            AlimentoNuevo.Imagen = imagen;
            AlimentoNuevo.Precio = precio;
            BindingContext = AlimentoNuevo;

            

        }
        private void Cerrar_Clicked(object sender, EventArgs e)
        {
           Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

    }
}