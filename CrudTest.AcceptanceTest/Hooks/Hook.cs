using BoDi;
using CrudTest.Infra.Data.Ef;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrudTest.AcceptanceTest.Hooks;

[Binding]
public sealed class CustomerHooks
{
    private readonly IObjectContainer _objectContainer;

    public CustomerHooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void BeforeSenarioRun()
    {
        var factory = GetWebApplicationFactory();
        _objectContainer.RegisterInstanceAs(factory);
    }

    [AfterScenario]
    public void AfterSenarioRun()
    {

    }

    private WebApplicationFactory<Api.Program> GetWebApplicationFactory()
    {
        return new WebApplicationFactory<Api.Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CrudTestDbContext>));
                    if (descriptor != null)
                        services.Remove(descriptor);
                    services.AddDbContext<CrudTestDbContext>(optBuilder =>
                    {
                        optBuilder.UseInMemoryDatabase("CrudTest.Test");
                        optBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Trace);
                    });
                });
                
            });
    }

}
