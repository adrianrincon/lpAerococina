using System;
using Xamarin.Forms;
using BigTed;
[assembly: Dependency(typeof(Aerococina.iOS.Dependencia.Hud))]
namespace Aerococina.iOS.Dependencia
{
    public class Hud : IHud
    {
        public void Cancel()
        {
            BTProgressHUD.Dismiss();
        }

        public void ShowError()
        {
            BTProgressHUD.ShowErrorWithStatus("");

        }

        public void ShowErrorMessage(string message)
        {
            BTProgressHUD.ShowErrorWithStatus(message);
        }

        public void ShowLoading()
        {
            BTProgressHUD.Show(null,-1,ProgressHUD.MaskType.Black);
        }

        public void ShowLoadingWithMessage(string message)
        {
            BTProgressHUD.Show(message, -1, ProgressHUD.MaskType.Black);
        }

        public void ShowSuccess()
        {
            BTProgressHUD.ShowSuccessWithStatus("");
        }

        public void ShowSuccessWithMessage(string message)
        {
            BTProgressHUD.ShowSuccessWithStatus(message);
        }

        public void ShowToast(string message)
        {
            BTProgressHUD.ShowToast(message, false);
        }
    }
}
