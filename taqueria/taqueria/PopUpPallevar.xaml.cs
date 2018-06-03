using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.TextToSpeech;
using System.IO;

namespace taqueria
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpPallevar
    {
        public Taco AlimentoNuevo { get; set; }
        string cantidad;
        public List<Taco> tacos { get; set; }
        string idPhone1;
        string sucursal;
        string json;
        
        public PopUpPallevar(string tipo,string descripcion, string imagen, string nombre, string precio,string indice, string idPhone, string numSucursal)
        {

            InitializeComponent();
            AlimentoNuevo = new Taco();
            AlimentoNuevo.Nombre = nombre;
            AlimentoNuevo.Descripcion = descripcion;
            AlimentoNuevo.Imagen = imagen;
            AlimentoNuevo.Precio = precio;
            AlimentoNuevo.Indice = indice;
            AlimentoNuevo.Tipo = tipo;
            BindingContext = AlimentoNuevo;
            
            for (int i = 0; i < 100; i++)
            {
                string a = i.ToString();
                Selector.Items.Add(a);
            }
            
            tacos = new List<Taco>();
            idPhone1 = idPhone;
            sucursal = numSucursal;

        }

        
        private void Selector_OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
           
            cantidad = Selector.Items[Selector.SelectedIndex];

        }
        public void Reproducir_audio(object sender, BackButtonPressedEventArgs e)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents,AlimentoNuevo.Indice+".txt");
            if (cantidad==null )
            {
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            }
            else
            {   if (!cantidad.Equals("0"))
                {
                    float total = Int32.Parse(cantidad) * float.Parse(AlimentoNuevo.Precio);
                    File.WriteAllText(filename, AlimentoNuevo.Tipo+" "+ AlimentoNuevo.Nombre + " ("
                            + cantidad + "(" + (total.ToString()) + ",");
                    Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
                    CrossTextToSpeech.Current.Speak("Agregado a la orden");
                }
                else {
                    File.Delete(filename);
                    Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
                    CrossTextToSpeech.Current.Speak("Eliminado de la orden");
                    
                }
                
            }
            
            /*tacos.Add(new Taco()
            {
                //Cantidad=cantidad,
                Nombre = AlimentoNuevo.Nombre,
                Imagen = AlimentoNuevo.Imagen,
                Precio = AlimentoNuevo.Precio,
                Descripcion = AlimentoNuevo.Descripcion,
                Cantidad = cantidad
            });*/
            
            /* if (File.Exists(filename))
             {
                 File.AppendAllText(filename, "Nombre: " + AlimentoNuevo.Nombre + " Cantidad: "
                    + cantidad + ",");
             }
             else
             {
                 File.WriteAllText(filename, "Nombre: " + AlimentoNuevo.Nombre + " Cantidad: "
                    + cantidad + ",");
             }*/
            //json = JsonConvert.SerializeObject(tacos);

        }

        protected override bool OnBackButtonPressed()
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            return true;
        }

        /*
        public List<Taco> GetList()
        {
            return tacos;
        }
       */
    }
}