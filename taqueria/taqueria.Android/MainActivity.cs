using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using scanner.cuerpos;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace taqueria.Droid
{
    [Activity(Label = "Tacos Tito", Icon = "@drawable/Logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static object Instance { get; internal set; }
        private string usuario;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Rg.Plugins.Popup.Popup.Init(this, bundle);

            CachedImageRenderer.Init(enableFastRenderer: true);
            Xamarin.FormsMaps.Init(this, bundle);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Android.Telephony.TelephonyManager mTelephonyMgr;
            mTelephonyMgr = (Android.Telephony.TelephonyManager)GetSystemService(TelephonyService);
            //IMEI number  
            String m_deviceId = mTelephonyMgr.DeviceId;
            var usuarios = new HealthGateway().UserName;
            
            if (usuarios == null)
            {
                //usuario = "10";
                usuario = new restClient().inserUser();
                new HealthGateway().SaveCredentials(usuario, "pass");
            }
            else {

                usuario = usuarios;
            }
            LoadApplication(application: new App(usuario));

            UserDialogs.Init(this);


        }
    }
}

