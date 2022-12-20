namespace CrudTest.Domain.Dto;

public class CustomerDto
{
    public int Id {get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
