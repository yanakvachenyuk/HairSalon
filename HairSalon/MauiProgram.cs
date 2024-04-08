using HairSalon.Entities;
using HairSalon.Pages;
using Microsoft.Extensions.Logging;
using HairSalon.Services;

namespace HairSalon;

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
        //var hairSalon = new MyHairSalon();
        builder.Services.AddSingleton<MyHairSalon>();
        builder.Services.AddTransient<LogInPage>();
        builder.Services.AddTransient<RegistrationPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<AdminProfilePage>();
        builder.Services.AddTransient<AdminMainPage>();
        builder.Services.AddTransient<ClientsCollectionPage>();
        builder.Services.AddTransient<ServiceTypesCollectionPage>();
        builder.Services.AddTransient<ServicesCollectionPage>();
        builder.Services.AddTransient<AdminsCollectionPage>();
        builder.Services.AddTransient<EmployeesCollectionPage>();
        builder.Services.AddTransient<EmployeeServiceTypesCollectionPage>();
        builder.Services.AddTransient<AccountsSystem>();
        builder.Services.AddTransient<AllServicesPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddClientPage>();
        builder.Services.AddTransient<AddServicePage>();


        builder.Services.AddSingleton<IDbService, SqLiteService>();
        //builder.Services.Add(hairSalon);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}