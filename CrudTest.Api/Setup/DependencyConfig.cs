using CrudTest.Application.Commands;
using CrudTest.Application.Mapping;
using CrudTest.Application.Validations;
using CrudTest.Domain.Common;
using CrudTest.Domain.Share;
using CrudTest.Infra.Data.Ef;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CrudTest.Api.Setup;
public static class DependencyConfig
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        var infrastructureType = typeof(CrudTestDbContext);
        var applicationType = typeof(CustomerCreateCommandHandler);
        var apiType = typeof(global::Program);
        services.Scan(scan => scan
            .FromAssembliesOf(infrastructureType, applicationType, apiType)
            .AddClasses(classes => classes.AssignableTo<ITransientService>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Scan(scan => scan
            .FromAssembliesOf(infrastructureType, applicationType, apiType)
            .AddClasses(classes => classes.AssignableTo<IScopedService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssembliesOf(infrastructureType, applicationType, apiType)
            .AddClasses(classes => classes.AssignableTo<ISingletonService>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        services.AddDbContext<CrudTestDbContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddValidatorsFromAssemblyContaining<CustomerCreateCommandValidator>();

        services.AddAutoMapper(typeof(Program), typeof(CustomerMapper));

        return services;
    }
}