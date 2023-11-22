using Pass_Keep.Resources.Constants.Themes;
using Pass_Keep.Resources.Preferences;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Settings;

class SettingsVM : INotifyPropertyChanged
{
    public SettingsVM()
    {
        this.CommandChangeToLightTheme = new(ChangeToLightTheme);
        this.CommandChangeToDarkTheme = new(ChangeToDarkTheme);

        this.IsAutoThemeEnabled = Preferences.Get(Preference.AutoThemeEnabled, true);
    }

    private void ChangeToLightTheme()
    {
        Preferences.Set(Preference.PreferredTheme, Themes.Light_Theme);
        App.Current.UserAppTheme = AppTheme.Light;
    }

    private void ChangeToDarkTheme()
    {
        Preferences.Set(Preference.PreferredTheme, Themes.Dark_Theme);
        App.Current.UserAppTheme = AppTheme.Dark;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(this, new(property_name));

    public Command CommandChangeToLightTheme { get; set; }
    public Command CommandChangeToDarkTheme { get; set; }

    private bool is_auto_theme_enabled;
    public bool IsAutoThemeEnabled
    {
        get => this.is_auto_theme_enabled;
        
        set
        {
            this.is_auto_theme_enabled = value;
            Preferences.Set(Preference.AutoThemeEnabled, value); 
            
            OnPropertyChanged(nameof(IsAutoThemeEnabled));
        }
    }

    public bool IsLoginEnabled
    {
        get => Preferences.Get(Preference.IsLoginEnabled, true);
        set { Preferences.Set(Preference.IsLoginEnabled, value); OnPropertyChanged(nameof(IsLoginEnabled)); }
    }

    public bool IsReLoginEnabled
    {
        get => Preferences.Get(Preference.IsReLoginEnabled, true);
        set { Preferences.Set(Preference.IsReLoginEnabled, value); OnPropertyChanged(nameof(IsReLoginEnabled)); }
    }
}