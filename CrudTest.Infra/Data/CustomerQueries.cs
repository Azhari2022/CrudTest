namespace CrudTest.Infra.Data;
public class CustomerQueries : ServiceBase, ICustomerQueries, IScopedService
{
    readonly CrudTestDbContext _context;
    readonly IMapper _mapper;

    public CustomerQueries(CrudTestDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<CustomerDto>> Get(CustomerGetQuery query)
    {
        var data = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == query.Id);
        return Ok(_mapper.Map<CustomerDto>(data));
    }

    public async Task<Response<DataList<CustomerDto>>> GetList(CustomerGetListQuery query)
    {
        var q = _context.Customers
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(query.Email))
        {
                q = q.Where(c =>  c.Email.Value==query.Email);
        }
        //q = q.Paging(query.Page, query.PageSize);
        
        var data = await q.ToListAsync();

        var count = await q.CountAsync();

        var mappedData = data.Select(d => _mapper.Map<CustomerDto>(d)).ToList();
        var dataList = mappedData
            .ToDataList(count, query);
        return Ok(dataList);
    }
}
