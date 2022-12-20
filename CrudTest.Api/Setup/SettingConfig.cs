using CrudTest.Domain.Common.Settings;

namespace CrudTest.Api.Setup;

public static class SettingConfig
{
    public static IServiceCollection AddAppSetting(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.Configure<AppSetting>(
                configuration.GetSection(AppSetting.Section));

        return services;
    } 
}
