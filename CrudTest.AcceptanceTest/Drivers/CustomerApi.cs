using System.Net.Http.Json;
using CrudTest.Api;
using CrudTest.Domain.Commands;
using CrudTest.Domain.Dto;
using CrudTest.Domain.Queries;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CrudTest.AcceptanceTest.Drivers;

public class CustomerApi
{
    WebApplicationFactory<Program> _factory;
    public CustomerApi(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private HttpClient CreateClient()
    {
        return _factory.CreateDefaultClient();
    }

    public async Task<Response<CustomerDto>?> CreateAsync(CustomerCreateCommand input)
    {
        using var client = CreateClient();
        var response = await client.PostAsJsonAsync("api/customer", input);
        return await response.Content.ReadFromJsonAsync<Response<CustomerDto>>();
    }

    public async Task<Response?> UpdateAsync(CustomerUpdateCommand input)
    {
        using var client = CreateClient();
        var response = await client.PutAsJsonAsync("api/customer", input);
        return await response.Content.ReadFromJsonAsync<Response>();
    }

    public async Task<Response?> DeleteAsync(int id)
    {
        using var client = CreateClient();
        var response = await client.DeleteAsync($"api/customer/{id}");
        return await response.Content.ReadFromJsonAsync<Response>();
    }

    public async Task<Response?> DeleteByEmailAsync(string email)
    {
        using var client = CreateClient();
        var response = await client.DeleteAsync($"api/customer/delete_by_email/{email}");
        return await response.Content.ReadFromJsonAsync<Response>();
    }

    public async Task<Response<CustomerDto>?> GetAsync(int id)
    {
        using var client = CreateClient();
        var response = await client.GetAsync($"api/customer/{id}");
        return await response.Content.ReadFromJsonAsync<Response<CustomerDto>>();
    }

    public async Task<Response<DataList<CustomerDto>>?> GetListAsync(CustomerGetListQuery query)
    {
        using var client = CreateClient();
        var response = await client.GetAsync($"api/customer?email={query.Email}&page={query.Page}&pageSize={query.PageSize}");
        return await response.Content.ReadFromJsonAsync<Response<DataList<CustomerDto>>>();
    }


}

public  class CodesDesc
{
    public int Code { get; set; }
    public string? Description { get; set; }
}
