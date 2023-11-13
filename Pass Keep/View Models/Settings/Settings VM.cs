using Pass_Keep.Resources.Preferences;
using Pass_Keep.Resources.Translations.Popup;
using Pass_Keep.Resources.Translations.View_Models.Settings;
using Pass_Keep.Services.Error_Informer;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Settings;

class SettingsVM : INotifyPropertyChanged
{
    public SettingsVM()
    {
        this.CommandChangePassword = new(async () => await ChangePassword());
        this.CommandDeleteHiddenAccounts = new(async () => await DeleteHiddenAccounts());
        this.CommandDeleteAllAccounts = new(async () => await DeleteAllAccounts());
    }

    private async Task ChangePassword()
    {
        // TODO
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

    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(this, new(property_name));

    public Command CommandChangePassword { get; set; }
    public Command CommandDeleteHiddenAccounts { get; set; }
    public Command CommandDeleteAllAccounts { get; set; }

    public bool IsAutoThemeEnabled
    {
        get => Preferences.Get(Preference.AutoThemeEnabled, true);
        set { Preferences.Set(Preference.AutoThemeEnabled, value); OnPropertyChanged(nameof(IsAutoThemeEnabled)); OnPropertyChanged(nameof(CustomThemeButtonsEnabled)); }
    }

    public bool CustomThemeButtonsEnabled { get => !this.IsAutoThemeEnabled; }

    public bool IsLoginEnabled
    {
        get => Preferences.Get(Preference.IsLoginEnabled, true);
        set { Preferences.Set(Preference.IsLoginEnabled, value); OnPropertyChanged(nameof(IsLoginEnabled)); }
    }

    public bool ActuallyDeleteAccounts
    {
        get => Preferences.Get(Preference.ActuallyDeleteAccounts, false);
        set { Preferences.Set(Preference.ActuallyDeleteAccounts, value); OnPropertyChanged(nameof(ActuallyDeleteAccounts)); }
    }
}