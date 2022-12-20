namespace CrudTest.Application.Mapping;
public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<CustomerInputDto, Customer>()
            .ForMember(f => f.Firstname,
                m => m.MapFrom(s => NameValueObject.From(s.Firstname))
            )
            .ForMember(f => f.Lastname,
                m => m.MapFrom(s => NameValueObject.From(s.Lastname))
            )
            .ForMember(f => f.DateOfBirth,
                m => m.MapFrom(s => DateOfBirthValueObject.From(s.DateOfBirth))
            )
            .ForMember(f => f.Email,
                m => m.MapFrom(s => EmailValueObject.From(s.Email))
            )
            .ForMember(f => f.PhoneNumber,
                m => m.MapFrom(s => MobileValueObject.From(s.PhoneNumber))
            )
            ;

        CreateMap<Customer, CustomerDto>()
            .ForMember(f => f.Firstname,
                m => m.MapFrom(s => s.Firstname!.Value)
            )
            .ForMember(f => f.Lastname,
                m => m.MapFrom(s => s.Lastname!.Value)
            )
            .ForMember(f => f.Email,
                m => m.MapFrom(s => s.Email!.Value)
            )
            .ForMember(f => f.DateOfBirth,
                m => m.MapFrom(s => s.DateOfBirth!.Value)
            )
            .ForMember(f => f.PhoneNumber,
                m => m.MapFrom(s => s.PhoneNumber!.Value)
            );
    }
}
