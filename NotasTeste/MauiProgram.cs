using Microsoft.Extensions.Logging;
using NotasTeste.Data;
using NotasTeste.Views;

namespace NotasTeste;

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

        builder.Services.AddSingleton<PaginaNotas>();
        builder.Services.AddTransient<PaginaTodasNotas>();
        builder.Services.AddTransient<PaginaSobre>();
        builder.Services.AddSingleton<NotasDatabase>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
