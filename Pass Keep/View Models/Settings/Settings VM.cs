using Pass_Keep.Resources.Translations.Popup;
using Pass_Keep.Resources.Translations.View_Models.Settings;
using Pass_Keep.Services.Error_Informer;

namespace Pass_Keep.View_Models.Settings;

class SettingsVM
{
    public SettingsVM()
    {
        this.CommandDeleteHiddenAccounts = new(async () => await DeleteHiddenAccounts());
        this.CommandDeleteAllAccounts = new(async () => await DeleteAllAccounts());
    }

    private async Task DeleteHiddenAccounts()
    {
        if (await Shell.Current.DisplayAlert(Popup.Warning, Localization.PopupDeleteHiddenAccounts, Popup.Yes, Popup.No))
        {
            try
            {
                // TODO
            } catch (Exception ex) { await ErrorInformer.Inform(nameof(SettingsVM), nameof(DeleteAllAccounts), Localization.ErrorDeletingHiddenAccounts, ex); }
        }
    }

    private async Task DeleteAllAccounts()
    {
        if (await Shell.Current.DisplayAlert(Popup.Warning, Localization.PopupDeleteAllAccounts, Popup.Yes, Popup.No))
        {
            try
            {
                // TODO
            } catch (Exception ex) { await ErrorInformer.Inform(nameof(SettingsVM), nameof(DeleteAllAccounts), Localization.ErrorDeletingAccounts, ex); }
        }
    }

    public Command CommandDeleteHiddenAccounts { get; set; }
    public Command CommandDeleteAllAccounts { get; set; }
}