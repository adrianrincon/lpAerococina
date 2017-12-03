using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace Aerococina.Droid
{
    [Activity(Label = "Aerococina.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            string nombreArchivo = "baseDatos.sqlite";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string ruta_db = Path.Combine(ruta, nombreArchivo);
            LoadApplication(new App(ruta_db));
        }

    }
}
