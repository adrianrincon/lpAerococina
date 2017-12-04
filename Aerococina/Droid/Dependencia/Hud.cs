using System;
using AndroidHUD;
using Xamarin.Forms;
[assembly: Dependency(typeof(Aerococina.Droid.Dependencia.Hud))]
namespace Aerococina.Droid.Dependencia
{
    public class Hud : IHud
    {
        public void Cancel()
        {
            AndHUD.Shared.CurrentDialog.Cancel();
        }

        public void ShowError()
        {
            AndHUD.Shared.ShowError(Xamarin.Forms.Forms.Context, null, MaskType.Black, TimeSpan.FromSeconds(2));
        }

        public void ShowErrorMessage(string message)
        {
            AndHUD.Shared.ShowError(Xamarin.Forms.Forms.Context, message, MaskType.Black, TimeSpan.FromSeconds(2));
        }

        public void ShowLoading()
        {
            AndHUD.Shared.Show(Xamarin.Forms.Forms.Context);
        }

        public void ShowLoadingWithMessage(string message)
        {
            AndHUD.Shared.Show(Xamarin.Forms.Forms.Context, message, -1, MaskType.Black);
        }

        public void ShowSuccess()
        {
            AndHUD.Shared.ShowSuccess(Xamarin.Forms.Forms.Context, null, MaskType.Black, TimeSpan.FromSeconds(2));
        }

        public void ShowSuccessWithMessage(string message)
        {
            AndHUD.Shared.ShowSuccessWithStatus(Xamarin.Forms.Forms.Context, message, MaskType.Black, TimeSpan.FromSeconds(2));
        }

        public void ShowToast(string message)
        {
            AndHUD.Shared.ShowToast(Xamarin.Forms.Forms.Context, message, MaskType.Black, TimeSpan.FromSeconds(2), false);
        }
    }
}
