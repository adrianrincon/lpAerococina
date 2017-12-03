using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace Aerococina.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            string nombreArchivo = "baseDatos.sqlite";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string ruta_db = Path.Combine(ruta, nombreArchivo);
            LoadApplication(new App(ruta_db));



            return base.FinishedLaunching(app, options);
        }
    }
}
