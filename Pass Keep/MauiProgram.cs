using CommunityToolkit.Maui;
using Pass_Keep.Models.Password_Models;

namespace Pass_Keep;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) => { handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent); });

        builder.Services.AddSingleton<AccountModelDB>();

        return builder.Build();
    }
}