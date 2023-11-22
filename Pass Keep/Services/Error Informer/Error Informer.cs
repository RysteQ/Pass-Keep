using Pass_Keep.Resources.Translations.Popup;

namespace Pass_Keep.Services.Error_Informer;

internal static class ErrorInformer
{
    public static async Task Inform(string view_model, string method, string friendly_error_description, Exception ex)
    {
        if (await Shell.Current.DisplayAlert(Popup.Error, $"{friendly_error_description}", Popup.Okay, Popup.Details) == false)
            await Shell.Current.DisplayAlert(Popup.Error, $"{view_model} - {method}\nException: {ex.Message}", Popup.Aknowledge);
    }
}