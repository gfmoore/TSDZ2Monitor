namespace TSDZ2Monitor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
      .UseMauiApp<App>()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    //dependency injection
    builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
    builder.Services.AddSingleton<IMap>(Map.Default);


    builder.Services.AddTransient<DisplayPage>();
    builder.Services.AddTransient<BluetoothPage>();
    builder.Services.AddTransient<BluetoothDetailPage>();

    builder.Services.AddTransient<TracksPage>();
    builder.Services.AddTransient<ParametersPage>();
    builder.Services.AddTransient<SettingsPage>();
    builder.Services.AddTransient<AboutPage>();

    builder.Services.AddTransient<ControlMenuViewModel>();
    builder.Services.AddTransient<BluetoothPeripheralsViewModel>();
    builder.Services.AddTransient<BluetoothPeripheralsDetailViewModel>();

    builder.Services.AddTransient<TracksViewModel>();

    return builder.Build();
	}
}
