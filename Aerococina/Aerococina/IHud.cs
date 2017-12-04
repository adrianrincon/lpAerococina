using System;
namespace Aerococina
{
    public interface IHud
    {
        void ShowLoading();
        void ShowLoadingWithMessage(string message);
        void ShowSuccess();
        void ShowSuccessWithMessage(string message);
        void ShowError();
        void ShowErrorMessage(string message);
        void ShowToast(string message);
        void Cancel();
    }
}
