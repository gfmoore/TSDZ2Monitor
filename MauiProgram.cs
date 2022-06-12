using TSDZ2Monitor.Extensions;

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

		return builder.Build();
	}
}
