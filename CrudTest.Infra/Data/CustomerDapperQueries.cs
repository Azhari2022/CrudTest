namespace CrudTest.Infra.Data;
public class CustomerDapperQueries : ServiceBase, ICustomerQueries//, IScopedService
{
    readonly IOptions<AppSetting> _appSetting;
    readonly IConfiguration _configuration;
    readonly IMapper _mapper;

    public CustomerDapperQueries(IOptions<AppSetting> appSetting, IConfiguration configuration, IMapper mapper)
    {
        _appSetting = appSetting;
        _configuration = configuration;
        _mapper = mapper;
    }


    public async Task<Response<CustomerDto>> Get(CustomerGetQuery query)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString(_appSetting.Value.ConnectionStringName));
        var item = await con.QuerySingleOrDefaultAsync<Customer>("dbo.spCustomerGet", new
        {
            query.Id
        }, commandType: System.Data.CommandType.StoredProcedure);
        if (item == null)
            return NotFound<CustomerDto>();

        return Ok(_mapper.Map<CustomerDto>(item));
    }
    public async Task<Response<Domain.Commands.DataList<CustomerDto>>> GetList(CustomerGetListQuery query)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString(_appSetting.Value.ConnectionStringName));
        var reader = await con.QueryMultipleAsync("dbo.spCustomerGetList", query,
            commandType: System.Data.CommandType.StoredProcedure);
        var items = await reader.ReadAsync<Customer>();
        var count = await reader.ReadSingleAsync<int>();
        return Ok(_mapper.Map<List<CustomerDto>>(items).ToDataList(count, query));
    }
}
