using Pass_Keep.Resources.Translations.Popup;

namespace Pass_Keep.Services.Error_Informer;

internal static class ErrorInformer
{
    public static async Task Inform(string friendly_error_description, Exception ex) => await Shell.Current.DisplayAlert(Popup.Error, $"{friendly_error_description}\nError: {ex.Message}", Popup.Aknowledge);
}