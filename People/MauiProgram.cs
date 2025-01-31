﻿using Microsoft.Extensions.Logging;
using People.Interfaces;
using People.ViewModels;

namespace People;

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
		string dbPath = FileAccessHelper.GetLocalFilePath("VelascoCrhystelpeople.db3");
		builder.Services.AddSingleton<PersonRepository>(c => ActivatorUtilities.CreateInstance<PersonRepository>(c, dbPath));
        builder.Services.AddSingleton<ICVPersonRepository, PersonRepository>();
        builder.Services.AddSingleton<CVelascoMPViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<CVTarjetaPage>();
        builder.Services.AddTransient<CVelascoTarjetaViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		// TODO: Add statements for adding PersonRepository as a singleton

		return builder.Build();
	}
}
