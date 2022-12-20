namespace CrudTest.Domain.Validators;

public static class NameValidator
{
    public static bool IsValid(string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && value.Length <= 256;
    }
}
