
namespace TSDZ2Monitor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
      .UseMauiApp<App>()
      .UseSkiaSharp()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    //dependency injection
    builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);

    builder.Services.AddTransient<StartPage>();
    builder.Services.AddTransient<StartViewModel>();

    builder.Services.AddTransient<Display1Page>();
    builder.Services.AddTransient<Display2Page>();
    builder.Services.AddTransient<Display3Page>();
    builder.Services.AddTransient<Display4Page>();
    builder.Services.AddTransient<Display5Page>();
    builder.Services.AddTransient<Display6Page>();

    builder.Services.AddTransient<Display1ViewModel>();
    builder.Services.AddTransient<Display2ViewModel>();
    builder.Services.AddTransient<Display3ViewModel>();
    builder.Services.AddTransient<Display4ViewModel>();
    builder.Services.AddTransient<Display5ViewModel>();
    builder.Services.AddTransient<Display6ViewModel>();


    builder.Services.AddTransient<BluetoothPage>();
    builder.Services.AddTransient<BluetoothDetailPage>();

    builder.Services.AddTransient<BluetoothPeripheralsViewModel>();
    builder.Services.AddTransient<BluetoothPeripheralsDetailViewModel>();


    builder.Services.AddTransient<TracksPage>();
    builder.Services.AddTransient<TracksListPage>();

    builder.Services.AddTransient<TracksViewModel>();
    builder.Services.AddTransient<TracksListViewModel>();


    builder.Services.AddTransient<ParametersPage>();
    builder.Services.AddTransient<SettingsPage>();
    builder.Services.AddTransient<AboutPage>();

    builder.Services.AddTransient<ControlMenuViewModel>();

    return builder.Build();
	}
}
