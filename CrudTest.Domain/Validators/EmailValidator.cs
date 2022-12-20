namespace CrudTest.Domain.Validators;

public static class EmailValidator
{
    public static bool IsValid(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        try
        {
            return EmailValidation.EmailValidator.Validate(value);
        }
        catch { return false; }
    }
}
