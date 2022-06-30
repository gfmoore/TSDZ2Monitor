namespace TSDZ2Monitor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()

			//from Extensions.OrganiseStartup
			.RegisterFonts()
			.RegisterHandlers()
			.RegisterServices();

    //dependency injection
    builder.Services.AddTransient<DisplayPage>();
    builder.Services.AddTransient<BluetoothPage>();
    builder.Services.AddTransient<TracksPage>();
    builder.Services.AddTransient<ParametersPage>();
    builder.Services.AddTransient<SettingsPage>();
    builder.Services.AddTransient<AboutPage>();

    builder.Services.AddTransient<ControlMenuViewModel>();
    builder.Services.AddTransient<BluetoothPeripheralsViewModel>();

    return builder.Build();
	}
}
